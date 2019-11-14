<template>
  <div>
    <v-row>
      <v-col>
        <v-card class="card-left">
          <v-tabs v-model="tab" grow>
            <v-tab>
              <v-icon left>mdi-gamepad-variant</v-icon>Twoje hobby
            </v-tab>
            <v-tab>
              <v-icon left>mdi-account-edit</v-icon>Edytuj profil
            </v-tab>
            <v-tab-item>
              <v-card flat>
                <v-card-text>
                  <Hobbies/>
                </v-card-text>
              </v-card>
            </v-tab-item>
            <v-tab-item>
              <v-card flat>
                <v-card-text>
                  <UserDetails/>
                </v-card-text>
              </v-card>
            </v-tab-item>
          </v-tabs>
        </v-card>
      </v-col>
      <v-col>
        <v-card class="card-right">
          <v-card-text>
            <ProfileView/>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </div>
</template>

<script>
import { mapActions } from 'vuex';

import Hobbies from './components/Hobbies';
import UserDetails from './components/UserDetails';
import ProfileView from './components/ProfileView';

export default {
  name: 'Profile',
  components: {
    Hobbies,
    UserDetails,
    ProfileView,
  },
  data () {
    return {
      tab: null,
    }
  },
  methods: {
    ...mapActions(['getUserDetails']),
  },
  async created() {
    await this.getUserDetails();
  },
}
</script>

<style lang="scss" scoped>
.card-left {
  margin-left: 10px;
}
.card-right {
  margin-right: 10px;
}
</style>