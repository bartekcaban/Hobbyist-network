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
};