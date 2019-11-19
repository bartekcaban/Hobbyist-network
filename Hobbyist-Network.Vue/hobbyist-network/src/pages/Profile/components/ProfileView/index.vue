<template>
  <div class="card">
    <v-row>
      <v-col cols="4">
        <v-img
          src="@/assets/avatar.png"
          width="200"
        ></v-img>
      </v-col>
      <v-col cols="8">
        <v-row>
          <v-col class="name">
            {{ currentUser.firstName }}, {{ age(currentUser.dateOfBirth) }}
          </v-col>
          <v-col class="city">
            {{ currentUser.city }}
          </v-col>
        </v-row>
        <v-row>
          <v-col class="description">
            {{ currentUser.description }}
          </v-col>
        </v-row>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <v-chip
          color="primary"
          class="hobby"
          v-for="hobby in currentUser.hobbies"
          v-bind:key="hobby.id"
        >
          <v-icon left>{{hobby.categoryIcon}}</v-icon>
          {{hobby.categoryName}}
          <div v-if="hobby.level === 1">
            <v-icon right class="level-icon">mdi-brush</v-icon>
          </div>
          <div v-if="hobby.level === 2">
            <v-icon right class="level-icon">mdi-brush</v-icon>
            <v-icon right class="level-icon">mdi-brush</v-icon>
          </div>
          <div v-if="hobby.level === 3">
            <v-icon right class="level-icon">mdi-brush</v-icon>
            <v-icon right class="level-icon">mdi-brush</v-icon>
            <v-icon right class="level-icon">mdi-brush</v-icon>
          </div>
          <div v-if="hobby.level === 4">
            <v-icon right class="level-icon">mdi-brush</v-icon>
            <v-icon right class="level-icon">mdi-brush</v-icon>
            <v-icon right class="level-icon">mdi-brush</v-icon>
            <v-icon right class="level-icon">mdi-brush</v-icon>
          </div>
        </v-chip>
      </v-col>
    </v-row>
    <v-row>
      <v-col v-if="currentUser.instagram">
        <v-icon class="instagram-icon">mdi-instagram</v-icon>
        <a :href="currentUser.instagram">{{currentUser.instagram}}</a>
      </v-col>
    </v-row>
    <v-row>
      <v-col v-if="currentUser.facebook">
        <v-icon class="facebook-icon">mdi-facebook</v-icon>
        <a :href="currentUser.instagram">{{currentUser.facebook}}</a>
      </v-col>
    </v-row>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  name: 'ProfileView',
  data () {
    return {
    }
  },
  computed: {
    ...mapGetters(['currentUser']),
  },
  methods: {
    age(dateOfBirth) {
      const date = new Date(dateOfBirth);
      const year = date.getFullYear();
      return new Date().getFullYear() - year;
    },
  }
}
</script>

<style lang="scss" scoped>
.name {
  font-size: xx-large;
  color: black;
}
.city {
  font-size: large;
  color: black;
}
.description {
  font-size: medium;
  color: black;
  max-height: 150px;
  overflow-y: auto;
}
.card {
  padding-left: 10px;
  padding-right: 10px;
}
.hobby {
  margin-right: 10px;
  margin-bottom: 10px;
  padding-right: 30px;
}
.level-icon {
  transform: rotate(-180deg);
  margin-right: -20px;
}
.facebook-icon {
  color: blue;
  margin-right: 5px;
}
.instagram-icon {
  color: red;
  margin-right: 5px;
}
</style>