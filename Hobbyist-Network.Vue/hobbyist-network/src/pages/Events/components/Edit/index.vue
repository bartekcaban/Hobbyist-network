<template>
  <div class="text-center">
    <v-dialog
      v-model="dialog"
      width="500"
    >
      <template v-slot:activator="{ on }">
        <v-btn
          icon
          color="secondary"
          text
          v-on="on"
        >
          <v-icon>mdi-pencil</v-icon>
        </v-btn>
      </template>
      <v-card>
        <v-card-title class="headline title">
          Edytuj wydarzenie
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
                  v-model="event.categoryId"
                  required
                  :rules="[v => !!v || 'Wymagane']"
                >
                </v-select>
              </v-col>
              <v-col>
                <v-text-field
                  label="Nazwa"
                  v-model="event.name"
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
                  v-model="event.localization"
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
                      v-model="event.startDate"
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
                    v-model="event.endDate"
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
                  v-model="event.description"
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
            @click="edit"
            :disabled="!valid"
          >
            Zapisz
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'EditEvent',
  data () {
    return {
      valid: false,
      endMenu: false,
      startMenu: false,
      dialog: false,
      startDate: null,
      endDate: null,
      startTime: null,
      endTime: null,
      datePickerStart: false,
      datePickerEnd: false,
      timePickerStart: false,
      timePickerEnd: false,
    }
  },
  computed: {
    ...mapGetters(['hobbyCategories', 'currentUser']),
  },
  props: {
    event: Object,
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
    ...mapActions(['editEvent', 'getEvents']),
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
      this.event.startDate = `${this.startDate} ${this.startTime}`;
    },
    timePickedEnd() {
      this.timePickerEnd = false;
      this.dateTimePickerEnd = false;
      this.event.endDate = `${this.endDate} ${this.endTime}`;
    },
    async edit() {
      await this.editEvent({
        categoryId: this.event.categoryId,
        name: this.event.name,
        id: this.event.id,
        localization: this.event.localization,
        description: this.event.description,
        startDate: this.event.startDate,
        endDate: this.event.endDate,
      });
      this.cancel();
    },
    async cancel() {
      this.dialog = false;
      await this.getEvents();
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