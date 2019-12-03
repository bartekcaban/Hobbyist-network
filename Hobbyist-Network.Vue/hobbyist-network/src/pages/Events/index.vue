<template>
  <div>
    <v-row>
      <v-col class="layout">
        <v-row>
          <v-col cols="12">
            <v-toolbar
              color="secondary"
              dark
              class="toolbar"
            >
              <v-toolbar-title>Wydarzenia</v-toolbar-title>
              <v-spacer></v-spacer>
              <div v-if="!currentUserEventsShown" class="select">
                <v-select
                  v-model="category"
                  :items="hobbyCategories"
                  item-text="name"
                  item-value="id"
                ></v-select>
              </div>
              <div v-if="!currentUserEventsShown">
                <v-btn
                  text
                  color="primary"
                  :disabled="!category"
                  @click="filter"
                >
                  Pokaż
                </v-btn>
              </div>
              <v-btn
                text
                @click="getAllEvents"
              >
                Wszystkie
              </v-btn>
              <v-btn
                text
                @click="showCurrentUserEvents"
                :disabled="currentUserEventsShown"
              >
                Moje
              </v-btn>
              <Add/>
            </v-toolbar>
          </v-col>
          <v-row class="grid" v-if="!currentUserEventsShown">
            <v-col
              v-for="event in filteredEvents"
              v-bind:key="event.id"
              cols="3"
            >
              <v-card color="primary" dark height="240">
                <v-card-title class="title">
                  <v-col cols="11" class="cols">
                    {{event.name}}
                  </v-col>
                  <v-col cols="1" class="cols">
                    <v-icon class="icon">{{event.categoryIcon}}</v-icon>
                  </v-col>
                  <div v-if="!currentUserIsOrganiser(event)" class="subtitle-2 organiser">by {{event.organiserFirstName}}</div>
                  <v-row v-if="currentUserIsOrganiser(event)" class="subtitle-2 organiser">
                    by you
                    <v-row class="actions">
                      <Edit :event="event"/>
                      <Delete :event="event"/>
                    </v-row>
                  </v-row>
                </v-card-title>
                <v-divider class="divider" dark></v-divider>
                <v-card-text>
                  <div class="white--text">{{event.localization}}</div>
                  <div class="white--text">{{event.startDate}} - {{event.endDate}}</div>
                  <div class="description">{{event.description}}</div>
                </v-card-text>
              </v-card>
            </v-col>
          </v-row>
          <v-row class="grid" v-if="currentUserEventsShown">
            <v-col
              v-for="event in currentUserEvents"
              v-bind:key="event.id"
              cols="3"
            >
              <v-card color="primary" dark height="240">
                <v-card-title class="title">
                  <v-col cols="11" class="cols">
                    {{event.name}}
                  </v-col>
                  <v-col cols="1" class="cols">
                    <v-icon class="icon">{{event.categoryIcon}}</v-icon>
                  </v-col>
                  <div v-if="!currentUserIsOrganiser(event)" class="subtitle-2 organiser">by {{event.organiserFirstName}}</div>
                  <v-row v-if="currentUserIsOrganiser(event)" class="subtitle-2 organiser">
                    by you
                    <v-row class="actions">
                      <Edit :event="event"/>
                      <Delete :event="event"/>
                    </v-row>
                  </v-row>
                </v-card-title>
                <v-divider class="divider" dark></v-divider>
                <v-card-text>
                  <div class="white--text">{{event.localization}}</div>
                  <div class="white--text">{{event.startDate}} - {{event.endDate}}</div>
                  <div class="description">{{event.description}}</div>
                </v-card-text>
              </v-card>
            </v-col>
          </v-row>
        </v-row>
      </v-col>
    </v-row>
  </div>
</template>

<script>
import { mapGetters, mapActions, mapMutations } from 'vuex';

import Add from './components/Add';
import Edit from './components/Edit';
import Delete from './components/Delete';

export default {
  name: 'Events',
  data: () => ({
    currentUserEventsShown: false,
    category: null,
  }),
  components: {
    Add,
    Edit,
    Delete,
  },
  computed: {
    ...mapGetters(['events', 'filteredEvents', 'currentUser', 'currentUserEvents', 'hobbyCategories']),
  },
  methods: {
    ...mapActions(['getEvents', 'getHobbyCategories', 'getUserDetails', 'getCurrentUserEvents']),
    ...mapMutations(['filterEvents']),
    currentUserIsOrganiser(event) {
      if (this.currentUser) {
        return event.organiserId === this.currentUser.id;
      } else {
        return false;
      }
    },
    filter() {
      this.filterEvents(this.category);
    },
    async showCurrentUserEvents() {
      this.currentUserEventsShown = true;
    },
    async getAllEvents() {
      await this.getEvents();
      this.currentUserEventsShown = false;
    },
  },
  async created() {
    await this.getEvents();
    await this.getUserDetails();
    await this.getHobbyCategories();
    await this.getCurrentUserEvents(this.currentUser.id);
  },
}
</script>

<style lang="scss" scoped>
@import '@/assets/styles/colors.scss';

.actions {
  margin-left: 10px;
  margin-top: -7px;
}
.title {
  height: 110px;
}
.cols {
  margin: -10px;
}
.layout {
  margin-right: 30px;
  margin-left: 30px;
}
.description {
  max-height: 60px;
  overflow-y: auto;
}
.icon {
  position: absolute;
  right: 20px;
  top: 20px;
}
.organiser {
  margin-left: 5px;
}
.grid {
  margin-left: 0px;
  margin-right: 0px;
}
.select {
  width: 200px;
  margin-top: 20px;
  margin-right: 10px;
}
</style>
