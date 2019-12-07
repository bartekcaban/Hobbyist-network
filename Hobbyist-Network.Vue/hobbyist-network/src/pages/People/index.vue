<template>
  <v-row class="layout">
    <v-row>
      <v-col>
        <v-toolbar
          color="secondary"
          dark
          class="toolbar"
        >
          <v-toolbar-title>Ludzie</v-toolbar-title>
          <v-spacer></v-spacer>
          <v-btn
            text
            @click="showMatchedUsers"
          >
            Poznani
          </v-btn>
        </v-toolbar>
      </v-col>
    </v-row>
    <v-row v-if="users[0]" class="card">
      <v-btn
        x-large
        icon
        text
        color="secondary"
        class="arrow-left"
        @click="notMatchUser"
      >
        <v-icon>
          mdi-arrow-left
        </v-icon>
      </v-btn>
      <v-card width="500">
        <v-card-text>
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
                  {{ users[0].firstName }}, {{ age(users[0].dateOfBirth) }}
                </v-col>
              </v-row>
              <v-row>
                <v-col class="city">
                  {{ users[0].city }}
                </v-col>
              </v-row>
              <v-row>
                <v-col class="description">
                  {{ users[0].description }}
                </v-col>
              </v-row>
            </v-col>
          </v-row>
          <v-row>
            <v-col>
              <v-tooltip
                :disabled="!hobby.description"
                top
                v-for="hobby in users[0].hobbies"
                v-bind:key="hobby.id"
              >
                <template v-slot:activator="{ on }">
                  <v-chip
                    color="primary"
                    class="hobby"
                    v-on="on"
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
                </template>
                <span>{{hobby.description}}</span>
              </v-tooltip>
            </v-col>
          </v-row>
          <v-row>
            <v-col v-if="users[0].instagram">
              <v-icon class="instagram-icon">mdi-instagram</v-icon>
              <a :href="users[0].instagram">{{users[0].instagram}}</a>
            </v-col>
          </v-row>
          <v-row>
            <v-col v-if="users[0].facebook">
              <v-icon class="facebook-icon">mdi-facebook</v-icon>
              <a :href="users[0].instagram">{{users[0].facebook}}</a>
            </v-col>
          </v-row>
        </v-card-text>
      </v-card>
      <v-btn
        x-large
        icon
        text
        color="primary"
        class="arrow-right"
        @click="matchUser"
      >
        <v-icon>
          mdi-arrow-right
        </v-icon>
      </v-btn>
    </v-row>
    <v-row v-if="!users[0]">
      <v-card class="card-empty">
        <v-card-text>
          Brak osób do pokazania
        </v-card-text>
      </v-card>
    </v-row>
  </v-row>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'People',
  data: () => ({

  }),
  computed: {
    ...mapGetters(['users', 'currentUser']),
  },
  methods: {
    ...mapActions(['getUsersForCurrentUser', 'getUserDetails', 'match', 'notMatch']),
    showMatchedUsers() {
      this.$router.push({
        name: 'Matches',
      });
    },
    age(dateOfBirth) {
      const date = new Date(dateOfBirth);
      const year = date.getFullYear();
      return new Date().getFullYear() - year;
    },
    matchUser() {
      this.match({ userId: this.currentUser.id, matchedUserId: this.users[0].id });
    },
    notMatchUser() {
      this.notMatch({ userId: this.currentUser.id, matchedUserId: this.users[0].id });
    },
  },
  async created() {
    await this.getUserDetails();
    await this.getUsersForCurrentUser(this.currentUser.id);
  }
}
</script>

<style lang="scss" scoped>
@import '@/assets/styles/colors.scss';
.layout {
  margin-right: 30px;
  margin-left: 30px;
  margin-bottom: 20px;
  margin-top:  20px;
}
.toolbar {
  width: 91rem;
}
.card {
  margin-left: 30%;
  margin-top: 20px;
}
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
  max-height: 100px;
  overflow-y: auto;
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
.arrow-left {
  margin-right: 10px;
  margin-top: 20%;
}
.arrow-right {
  margin-left: 10px;
  margin-top: 20%;
}
.card-empty {
  margin-left: 650px;
  margin-top: 200px;
}
</style>
