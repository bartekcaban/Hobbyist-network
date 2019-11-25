<template>
  <div class="text-center">
    <v-dialog
      v-model="dialog"
      width="500"
    >
      <template v-slot:activator="{ on }">
        <v-btn
          icon
          text
          v-on="on"
        >
          <v-icon>mdi-plus-thick</v-icon>
        </v-btn>
      </template>
      <v-card>
        <v-card-title class="headline title">
          Dodaj nowe wydarzenie
        </v-card-title>
        <v-card-text>
          <v-form ref="form" v-model="valid">
            <v-row>
              <v-col>
                <v-select
                  :items="hobbyCategories"
                  item-value="id"
                  item-text="name"
                  label="Kategoria"
                  v-model="categoryId"
                  required
                  :rules="[v => !!v || 'Wymagane']"
                >
                </v-select>
              </v-col>
              <v-col>
                <v-text-field
                  label="Nazwa"
                  v-model="name"
                  required
                  :rules="[v => !!v || 'Wymagane']"
                >
                </v-text-field>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-text-field
                  label="Lokalizacja"
                  v-model="localization"
                  required
                  :rules="[v => !!v || 'Wymagane']"
                >
                </v-text-field>
              </v-col>
            </v-row>
            <v-row>
                <v-col>
                <v-menu
                  ref="startMenu"
                  :close-on-content-click="false"
                  v-model="startMenu"
                  transition="scale-transition"
                  offset-y
                  min-width="290px"
                >
                  <template v-slot:activator="{ on }">
                    <v-text-field
                      label="Data startu"
                      append-icon="event"
                      v-model="startDateTime"
                      readonly
                      v-on="on"
                      required
                      :rules="[v => !!v || 'Wymagane']"
                    ></v-text-field>
                  </template>
                  <v-date-picker
                    v-if="datePickerStart"
                    first-day-of-week="1"
                    v-model="startDate"
                    @input="saveStartDate"
                    max="2030-12-31"
                    ref="startPicker"
                    scrollable
                    locale="pl"
                    min="1900-01-01"
                  ></v-date-picker>
                  <v-time-picker
                    v-if="timePickerStart"
                    locale="pl"
                    scrollable
                    format="24hr"
                    v-model="startTime"
                    @click:minute="timePickedStart"
                  />
                </v-menu>
              </v-col>
              <v-col>
                <v-menu
                  ref="endMenu"
                  :close-on-content-click="false"
                  v-model="endMenu"
                  transition="scale-transition"
                  offset-y
                  min-width="290px"
                >
                  <template v-slot:activator="{ on }">
                  <v-text-field
                    label="Data zakończenia"
                    append-icon="event"
                    v-model="endDateTime"
                    readonly
                    v-on="on"
                    required
                    :rules="[v => !!v || 'Wymagane']"
                  ></v-text-field>
                  </template>
                  <v-date-picker
                    v-if="datePickerEnd"
                    first-day-of-week="1"
                    v-model="endDate"
                    @input="saveEndDate"
                    max="2030-12-31"
                    ref="endPicker"
                    scrollable
                    locale="pl"
                    min="1900-01-01"
                  ></v-date-picker>
                  <v-time-picker
                    v-if="timePickerEnd"
                    locale="pl"
                    scrollable
                    format="24hr"
                    v-model="endTime"
                    @click:minute="timePickedEnd"
                  />
                </v-menu>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-textarea
                  v-model="description"
                  label="Opis"
                  counter="100"
                ></v-textarea>
              </v-col>
            </v-row>
          </v-form>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="secondary"
            @click="cancel"
          >
            Anuluj
          </v-btn>
          <v-btn
            color="primary"
            @click="add"
            :disabled="!valid"
          >
            Dodaj
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'AddEvent',
  data () {
    return {
      valid: false,
      endMenu: false,
      startMenu: false,
      dialog: false,
      categoryId: null,
      name: null,
      description: null,
      localization: null,
      startDate: null,
      endDate: null,
      startTime: null,
      endTime: null,
      startDateTime: null,
      endDateTime: null,
      datePickerStart: false,
      datePickerEnd: false,
      timePickerStart: false,
      timePickerEnd: false,
    }
  },
  computed: {
    ...mapGetters(['hobbyCategories', 'currentUser']),
  },
  watch: {
    startMenu(val) {
      val && setTimeout(() => (this.$refs.startPicker.activePicker = 'YEAR'))
      this.datePickerStart = true;
    },
    endMenu(val) {
      val && setTimeout(() => (this.$refs.endPicker.activePicker = 'YEAR'))
      this.datePickerEnd = true;
    },
  },
  methods: {
    ...mapActions(['addEvent', 'getEvents', 'getCurrentUserEvents']),
    saveStartDate() {
      this.datePickerStart = false;
      this.timePickerStart = true;
    },
    saveEndDate() {
      this.datePickerEnd = false;
      this.timePickerEnd = true;
    },
    timePickedStart() {
      this.timePickerStart = false;
      this.dateTimePickerStart = false;
      this.startDateTime = `${this.startDate} ${this.startTime}`;
    },
    timePickedEnd() {
      this.timePickerEnd = false;
      this.dateTimePickerEnd = false;
      this.endDateTime = `${this.endDate} ${this.endTime}`;
    },
    async add() {
      await this.addEvent({
        categoryId: this.categoryId,
        name: this.name,
        organiserId: this.currentUser.id,
        localization: this.localization,
        description: this.description,
        startDate: this.startDateTime,
        endDate: this.endDateTime,
      });
      await this.getEvents();
      await this.getCurrentUserEvents(this.currentUser.id);
      this.cancel();
    },
    cancel() {
      this.dialog = false;
      this.description = null;
      this.categoryId = null;
      this.name = null;
      this.localization = null;
      this.startDate = null;
      this.endDate = null;
    },
  },
}
</script>

<style lang="scss" scoped>
@import '@/assets/styles/colors.scss';

.title {
  color: white;
  background-color: $primary;
}
</style>