<template>
  <v-app light>
    <Navbar v-if="showNavbar()"/>
    <v-content>
      <router-view></router-view>
    </v-content>
  </v-app>
</template>

<script>
import Navbar from './components/Navbar';

export default {
  name: 'App',
  components: {
    Navbar,
  },
  methods: {
    showNavbar() {
      return this.$route.path !== '/';
    },
  },
};
</script>
