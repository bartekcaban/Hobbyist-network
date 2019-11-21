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
              <v-btn
                text
                @click="getAllEvents"
              >
                Wszystkie
              </v-btn>
              <v-btn
                text
                @click="showCurrentUserEvents"
              >
                Moje
              </v-btn>
              <v-btn
                icon
                text
              >
                <Add/>
              </v-btn>
            </v-toolbar>
          </v-col>
          <v-col
            v-for="event in events"
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
      </v-col>
    </v-row>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

import Add from './components/Add';
import Edit from './components/Edit';
import Delete from './components/Delete';

export default {
  name: 'Events',
  data: () => ({

  }),
  components: {
    Add,
    Edit,
    Delete,
  },
  computed: {
    ...mapGetters(['events', 'currentUser']),
  },
  methods: {
    ...mapActions(['getEvents', 'getHobbyCategories', 'getUserDetails', 'getCurrentUserEvents']),
    currentUserIsOrganiser(event) {
      if (this.currentUser) {
        return event.organiserId === this.currentUser.id;
      } else {
        return false;
      }
    },
    async showCurrentUserEvents() {
      await this.getCurrentUserEvents(this.currentUser.id);
    },
    async getAllEvents() {
      await this.getEvents();
    },
  },
  async created() {
    await this.getEvents();
    await this.getUserDetails();
    await this.getHobbyCategories();
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
</style>
