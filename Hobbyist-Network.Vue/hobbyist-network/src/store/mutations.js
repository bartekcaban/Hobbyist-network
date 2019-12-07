export default {
  setCurrentUser(state, user) {
    state.currentUser = user;
  },
  setCurrentUserInLocalStorage(state, user) {
    const parsedUserDetails = JSON.stringify(user);
    localStorage.setItem('currentUser', parsedUserDetails);
  },
  setSignOut(state) {
    localStorage.clear();
    state.currentUser = {};
  },
  setHobbyCategories(state, categories) {
    state.hobbyCategories = categories;
  },
  addHobbyToList(state, hobby) {
    state.currentUser.hobbies.push(hobby);
  },
  setEvents(state, events) {
    state.events = events;
    state.filteredEvents = events;
  },
  setCurrentUserEvents(state, events) {
    state.currentUserEvents = events;
  },
  filterEvents(state, category) {
    state.filteredEvents = state.events.filter(event => event.categoryId = category);
  },
  setUsers(state, users) {
    state.users = users;
  },
  setMatchedUsers(state, users) {
    state.matchedUsers = users;
  },
  deleteUserFromList(state, id) {
    state.users = state.users.filter(u => u.id !== id);
  },
  deleteContactFromList(state, id) {
    state.matchedUsers = state.matchedUsers.filter(m => m.id !== id);
  },
};