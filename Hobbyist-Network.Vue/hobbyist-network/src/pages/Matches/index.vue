<template>
  <div>
    <v-row>
      <v-col>
        <v-card class="card-left">
          <v-card-title class="title white--text">
            Moje poznane osoby
          </v-card-title>
          <v-card-text>
            <v-list>
              <v-list-item-group color="primary" v-model="contact">
                <v-list-item
                  v-for="contact in matchedUsers"
                  :key="contact.id"
                  @click="setCurrentContact(contact)"
                >
                  <v-list-item-icon>
                    <v-icon class="person-icon">mdi-account</v-icon>
                  </v-list-item-icon>
                  <v-list-item-content>
                    <v-list-item-title>
                      {{ contact.firstName }} {{contact.lastName}}
                    </v-list-item-title>
                  </v-list-item-content>
                  <v-list-item-action>
                      <v-btn text @click="showDialog(contact.id)">
                        <v-icon class="person-icon">mdi-delete</v-icon>
                      </v-btn>
                    </v-list-item-action>
                </v-list-item>
              </v-list-item-group>
            </v-list>
          </v-card-text>
        </v-card>
      </v-col>
      <v-col>
        <v-card v-if="currentContact" class="card-right">
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
                    {{ currentContact.firstName }}, {{ age(currentContact.dateOfBirth) }}
                  </v-col>
                </v-row>
                <v-row>
                  <v-col class="city">
                    {{ currentContact.city }}
                  </v-col>
                </v-row>
                <v-row>
                  <v-col class="description">
                    {{ currentContact.description }}
                  </v-col>
                </v-row>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-tooltip
                  :disabled="!hobby.description"
                  top
                  v-for="hobby in currentContact.hobbies"
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
              <v-col v-if="currentContact.instagram">
                <v-icon class="instagram-icon">mdi-instagram</v-icon>
                <a :href="currentContact.instagram">{{currentContact.instagram}}</a>
              </v-col>
            </v-row>
            <v-row>
              <v-col v-if="currentContact.facebook">
                <v-icon class="facebook-icon">mdi-facebook</v-icon>
                <a :href="currentContact.instagram">{{currentContact.facebook}}</a>
              </v-col>
            </v-row>
            <v-row>
              <v-col class="contacts">
                <v-icon class="phone-icon">mdi-phone</v-icon>
                {{currentContact.phoneNumber}}
              </v-col>
            </v-row>
            <v-row>
              <v-col class="contacts">
                <v-icon class="at-icon">mdi-at</v-icon>
                {{currentContact.email}}
              </v-col>
            </v-row>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
    <v-dialog
      v-model="dialog"
      width="500"
    >
      <v-card>
        <v-card-text>
          <v-row>
            <v-col class="text-center dialog-title">
              Czy na pewno chcesz usunąć ten kontakt?
            </v-col>
          </v-row>
        </v-card-text>
        <v-card-actions class="buttons">
          <v-btn
            color="secondary"
            @click="closeDialog"
          >
            Nie
          </v-btn>
          <v-btn
            color="primary"
            @click="deleteC"
          >
            Tak
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script>
import { mapMutations, mapGetters, mapActions } from 'vuex';

export default {
  name: 'Matches',
  data () {
    return {
      contact: null,
      dialog: false,
      id: null,
    }
  },
  computed: {
    ...mapGetters(['currentContact', 'matchedUsers', 'currentUser']),
  },
  methods: {
    ...mapMutations(['setCurrentContact']),
    ...mapActions(['getMatchedUsersForCurrentUser', 'deleteContact', 'getUserDetails']),
    age(dateOfBirth) {
      const date = new Date(dateOfBirth);
      const year = date.getFullYear();
      return new Date().getFullYear() - year;
    },
    showDialog(id) {
      this.dialog = true;
      this.id = id;
    },
    closeDialog() {
      this.dialog = false;
      this.id = null;
    },
    deleteC() {
      this.deleteContact(this.id);
      this.setCurrentContact(null);
      this.closeDialog();
    },
  },
  async created() {
    await this.getUserDetails();
    await this.getMatchedUsersForCurrentUser(this.currentUser.id);
  },
}
</script>

<style lang="scss" scoped>
@import '@/assets/styles/colors.scss';
.card-left {
  margin-left: 10px;
}
.card-right {
  margin-right: 10px;
}
.title {
  background-color: $secondary;
}
.person-icon {
  color: $secondary;
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
.at-icon {
  color: black;
  margin-right: 5px;
}
.phone-icon {
  color: green;
  margin-right: 5px;
}
.contacts {
  font-size: medium;
  color: black;
}
.dialog-title {
  margin-top: 20px;
  color: $secondary;
}
.buttons {
  display: flex;
  justify-content: space-between;
  margin-left: 20%;
  margin-right: 20%;
  margin-top: 20px;
  padding-bottom: 20px;
}
</style>