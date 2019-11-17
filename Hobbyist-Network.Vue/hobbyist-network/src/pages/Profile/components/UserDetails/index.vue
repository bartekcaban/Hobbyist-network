<template>
  <div>
    <v-form ref="form" v-model="valid">
      <v-row>
        <v-col>
          <v-text-field
            label="Imię"
            v-model="currentUser.firstName"
            required
            :rules="[v => !!v || 'Wymagane']"
          ></v-text-field>
        </v-col>
        <v-col>
          <v-text-field
            label="Nazwisko"
            v-model="currentUser.lastName"
            required
            :rules="[v => !!v || 'Wymagane']"
          ></v-text-field>
        </v-col>
        <v-col>
          <v-menu
            ref="menu"
            :close-on-content-click="false"
            v-model="menu"
            transition="scale-transition"
            offset-y
            min-width="290px"
          >
            <template v-slot:activator="{ on }">
              <v-text-field
                label="Data urodzenia"
                append-icon="event"
                v-model="currentUser.dateOfBirth"
                readonly
                v-on="on"
                required
                :rules="[v => !!v || 'Wymagane']"
              ></v-text-field>
            </template>
            <v-date-picker
              first-day-of-week="1"
              v-model="currentUser.dateOfBirth"
              @change="saveDate"
              ref="picker"
              scrollable
              locale="pl"
              :max="new Date().toISOString().substr(0, 10)"
              min="1900-01-01"
            ></v-date-picker>
          </v-menu>
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <v-text-field
            label="Numer telefonu"
            v-model="currentUser.phoneNumber"
            required
            :rules="[v => !!v || 'Wymagane']"
          ></v-text-field>
        </v-col>
        <v-col>
          <v-text-field
            label="Miasto"
            v-model="currentUser.city"
            required
            :rules="[v => !!v || 'Wymagane']"
          ></v-text-field>
        </v-col>
        <v-col>
          <v-select
            :items="genders"
            v-model="currentUser.gender"
            label="Płeć"
            required
            :rules="[v => !!v || 'Wymagane']"
          ></v-select>
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <v-text-field
            label="Instagram (link)"
            prepend-icon="mdi-instagram"
            v-model="currentUser.instagram"
          ></v-text-field>
        </v-col>
        <v-col>
          <v-text-field
            label="Facebook (link)"
            prepend-icon="mdi-facebook"
            v-model="currentUser.facebook"
          ></v-text-field>
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <v-textarea
            label="Opis"
            v-model="currentUser.description"
          ></v-textarea>
        </v-col>
      </v-row>
    </v-form>
    <v-row>
      <v-spacer></v-spacer>
       <v-btn
        color="secondary"
        class="save"
        @click="openChangePasswordDialog"
      >
        Zmień hasło
      </v-btn>
      <v-btn
        color="primary"
        class="save"
        :disabled="!valid"
        @click="save"
      >
        Zapisz
      </v-btn>
    </v-row>
    <ChangePassword :changePasswordDialog="changePasswordDialog" @close="closeChangePasswordDialog"/>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

import { GENDERS } from '@/shared/constants';

import ChangePassword from './components/ChangePassword';

export default {
  name: 'UserDetails',
  data () {
    return {
      valid: false,
      menu: false,
      genders: GENDERS,
      changePasswordDialog: false,
    }
  },
  computed: {
    ...mapGetters(['currentUser']),
  },
  components: {
    ChangePassword,
  },
  watch: {
    menu(val) {
      val && setTimeout(() => (this.$refs.picker.activePicker = 'YEAR'))
    },
  },  
  methods: {
    ...mapActions(['updateUser']),
    openChangePasswordDialog() {
      this.changePasswordDialog = true;
    },
    closeChangePasswordDialog() {
      this.changePasswordDialog = false;
    },
    async save() {
      await this.updateUser(this.currentUser);
    },
    saveDate(date) {
      this.$refs.menu.save(date)
    },
  },
}
</script>

<style lang="scss" scoped>
.save {
  margin-right: 10px;
}
</style>