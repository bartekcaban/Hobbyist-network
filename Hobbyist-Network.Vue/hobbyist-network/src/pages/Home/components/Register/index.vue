<template>
  <v-dialog
    max-width="900"
    v-model="registerDialog"
    persistent
  >
    <v-card>
      <v-card-title class="headline title">Zarejestruj się</v-card-title>
      <v-card-text>
        <v-form ref="form" v-model="valid">
          <v-row>
            <v-col>
              <v-text-field
                label="Imię"
                v-model="firstName"
                required
                :rules="[v => !!v || 'Wymagane']"
              ></v-text-field>
            </v-col>
            <v-col>
              <v-text-field
                label="Nazwisko"
                v-model="lastName"
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
                    v-model="dateOfBirth"
                    readonly
                    v-on="on"
                    required
                    :rules="[v => !!v || 'Wymagane']"
                  ></v-text-field>
                </template>
                <v-date-picker
                  first-day-of-week="1"
                  v-model="dateOfBirth"
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
            <v-col cols="6">
              <v-text-field
                label="Email"
                v-model="email"
                required
                :rules="[v => !!v || 'Wymagane']"
              ></v-text-field>
            </v-col>
            <v-col>
              <v-text-field
                label="Hasło"
                type="password"
                v-model="password"
                required
                :rules="[v => !!v || 'Wymagane']"
              ></v-text-field>
            </v-col>
            <v-col>
              <v-text-field
                label="Powtórz hasło"
                type="password"
                v-model="confirmPassword"
                required
                :rules="[v => !!v || 'Wymagane']"
              ></v-text-field>
            </v-col>
          </v-row>
          <v-row>
            <v-col>
              <v-select
                :items="genders"
                v-model="gender"
                label="Płeć"
                required
                :rules="[v => !!v || 'Wymagane']"
              ></v-select>
            </v-col>
            <v-col>
              <v-text-field
                label="Numer telefonu"
                v-model="phoneNumber"
                required
                :rules="[v => !!v || 'Wymagane']"
              ></v-text-field>
            </v-col>
            <v-col>
              <v-text-field
                label="Miasto"
                v-model="city"
                required
                :rules="[v => !!v || 'Wymagane']"
              ></v-text-field>
            </v-col>
          </v-row>
          <v-row>
            <v-col>
              <v-textarea
                label="Opis"
                v-model="description"
              ></v-textarea>
          </v-col>
          </v-row> 
        </v-form>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn
          color="secondary"
          @click="close"
        >Anuluj
        </v-btn>
        <v-btn
          color="primary"
          @click="register"
          :disabled="!valid"
        >Zarejestruj
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapActions } from 'vuex';

import { GENDERS } from '@/shared/constants';

export default {
  name: 'Register',
  data: () => ({
    valid: false,
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    confirmPassword: '',
    description: '',
    gender: null,
    dateOfBirth: '',
    city: '',
    phoneNumber: '',
    userDetailsDialog: false,
    menu: false,
    genders: GENDERS,
  }),
  watch: {
    menu(val) {
      val && setTimeout(() => (this.$refs.picker.activePicker = 'YEAR'))
    },
  },
  props: {
    registerDialog: Boolean,
  },
  methods: {
    ...mapActions(['registerUser', 'loginUser']),
    async register() {
      if (this.$refs.form.validate()) {
        await this.registerUser({
          firstName: this.firstName,
          lastName: this.lastName,
          email: this.email,
          password: this.password,
          confirmPassword: this.confirmPassword,
          dateOfBirth: this.dateOfBirth,
          gender: this.gender, city: this.city,
          phoneNumber: this.phoneNumber,
          description: this.description,
        });
        await this.loginUser({ email: this.email, password: this.password });
        this.$router.push({
          name: 'Main',
        });
        this.$emit('close');
      }
    },
    saveDate(date) {
      this.$refs.menu.save(date)
    },
    close() {
      this.$emit('close');
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
