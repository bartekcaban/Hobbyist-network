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
    <v-row><v-card color="secondary">
      <v-col>
        
        <v-chip color="primary" class="hobby">
          <v-icon left>mdi-fountain-pen</v-icon>
          <v-icon left>mdi-brush</v-icon>
          <v-icon left>mdi-brush</v-icon>
          <v-icon left>mdi-brush</v-icon>
          Koszykówka
          <v-avatar
            right
            color="primary"
          >
            1
          </v-avatar>
        </v-chip>
        <v-chip color="primary" class="hobby">
          <v-icon left>mdi-gamepad-variant</v-icon>
          Szachy
        </v-chip>
      </v-col></v-card>
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
  transform: rotate(-180deg);
  margin-right: 10px;
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