<template>
  <div>
    <v-app-bar
      app
      dark
      color="primary"
    >
      <v-toolbar-title>Meet Your Match</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn
        icon
        text
        large
        @click="goToMain"
      >
        <v-icon>mdi-home</v-icon>
      </v-btn>
      <v-btn
        icon
        text
        large
        @click="goToProfile"
      >
        <v-icon>mdi-account</v-icon>
      </v-btn>
      <v-btn
        icon
        text
        large
        class="button"
        @click="signOut"
      >
        <v-icon>mdi-logout-variant</v-icon>
      </v-btn>
    </v-app-bar>
  </div>
</template>

<script>
import { mapMutations } from 'vuex';

export default {
  name: 'Navbar',
  data: () => ({
  }),
  methods: {
    ...mapMutations(['setSignOut']),
    goToMain() {
      if (this.$route.path !== '/main') {
        this.$router.push({
          name: 'Main',
        });
      }
    },
    goToProfile() {
      if (this.$route.path !== '/profile') {
        this.$router.push({
          name: 'Profile',
        });
      }
    },
    signOut() {
      this.setSignOut();
      this.$router.push({
        name: 'Home',
      });
    },
  },
}
</script>

<style lang="scss" scoped>

.button {
  margin-right: 30px;
}
</style>