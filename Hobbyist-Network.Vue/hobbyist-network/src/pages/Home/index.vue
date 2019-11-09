<template>
  <div>
    <v-app-bar dark color="secondary">
      <v-toolbar-title>Meet Your Match</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn color="primary" @click="openLoginDialog">Zaloguj się</v-btn>
    </v-app-bar>
    <v-content>
      <section>
        <v-parallax src="@/assets/tłozapałki.jpg" height="600">
          <v-layout
            column
            align-center
            justify-center
          >
            <!-- <img src="assets/vuetify.png" alt="Vuetify.js" height="200"> logo-->
            <h1 class="mb-2 display-1 text-center">Meet Your Match</h1>
            <v-btn
              class="mt-12"
              dark
              large
              color="secondary"
              @click="openRegisterDialog"
            >Zarejestruj się
            </v-btn>
          </v-layout>
        </v-parallax>
      </section>
      <section class="secondary">
        <v-layout
          column
          wrap
          align-center
        >
          <v-flex xs12 sm4 class="my-4">
            <div class="text-center white--text">
              <h2 class="headline">Najlepsze miejsce dla ludzi z pasjami</h2>
              <span class="subheading">
                Znajdź osoby o wspólnych zainteresowaniach
              </span>
            </div>
          </v-flex>
          <!-- <v-flex xs12>
            <v-container grid-list-xl>
              <v-layout row wrap align-center>
                <v-flex xs12 md4>
                  <v-card flat class="transparent">
                    <v-card-text class="text-center">
                      <v-icon x-large class="blue--text text--lighten-2">mdi-palette</v-icon>
                    </v-card-text>
                    <v-card-title primary-title class="layout justify-center">
                      <div class="headline text-center">Material Design</div>
                    </v-card-title>
                    <v-card-text>
                      Cras facilisis mi vitae nunc lobortis pharetra. Nulla volutpat tincidunt ornare.
                      Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.
                      Nullam in aliquet odio. Aliquam eu est vitae tellus bibendum tincidunt. Suspendisse potenti.
                    </v-card-text>
                  </v-card>
                </v-flex>
                <v-flex xs12 md4>
                  <v-card flat class="transparent">
                    <v-card-text class="text-center">
                      <v-icon x-large class="blue--text text--lighten-2">mdi-flash</v-icon>
                    </v-card-text>
                    <v-card-title primary-title class="layout justify-center">
                      <div class="headline">Fast development</div>
                    </v-card-title>
                    <v-card-text>
                      Cras facilisis mi vitae nunc lobortis pharetra. Nulla volutpat tincidunt ornare.
                      Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.
                      Nullam in aliquet odio. Aliquam eu est vitae tellus bibendum tincidunt. Suspendisse potenti.
                    </v-card-text>
                  </v-card>
                </v-flex>
                <v-flex xs12 md4>
                  <v-card flat class="transparent">
                    <v-card-text class="text-center">
                      <v-icon x-large class="blue--text text--lighten-2">mdi-wrench</v-icon>
                    </v-card-text>
                    <v-card-title primary-title class="layout justify-center">
                      <div class="headline text-center">Completely Open Sourced</div>
                    </v-card-title>
                    <v-card-text>
                      Cras facilisis mi vitae nunc lobortis pharetra. Nulla volutpat tincidunt ornare.
                      Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.
                      Nullam in aliquet odio. Aliquam eu est vitae tellus bibendum tincidunt. Suspendisse potenti.
                    </v-card-text>
                  </v-card>
                </v-flex>
              </v-layout>
            </v-container>
          </v-flex> -->
        </v-layout>
      </section>
      <v-parallax src="@/assets/tłozapałki.jpg" height="300">
          <v-layout
            column
            align-center
            justify-center
          >
            <v-btn
              class="mt-12"
              dark
              large
              color="secondary"
              @click="openRegisterDialog"
            >Zarejestruj się
            </v-btn>
          </v-layout>
        </v-parallax>
      <v-footer color="secondary" dark>
        by Bartłomiej Caban
      </v-footer>
    </v-content>
    <Login :loginDialog="loginDialog" @close="closeLoginDialog"/>
    <Register :registerDialog="registerDialog" @close="closeRegisterDialog"/>
  </div>
 </template>

<script>
import Register from './components/Register';
import Login from './components/Login';

export default {
  name: 'Home',
  data: () => ({
    registerDialog: false,
    loginDialog: false,
  }),
  components: {
    Register,
    Login,
  },
  methods: {
    openRegisterDialog() {
      this.registerDialog = true;
    },
    openLoginDialog() {
      this.loginDialog = true;
    },
    closeRegisterDialog() {
      this.registerDialog = false;
    },
    closeLoginDialog() {
      this.loginDialog = false;
    },
  },
}
</script>

<style lang="scss" scoped>
@import '@/assets/styles/colors.scss';

.layout {
  height: 160px;
  justify-content: center;
}
</style>
