// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { getAuth} from "firebase/auth";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
  apiKey: "AIzaSyAfCSI4340wyHX78Lxudw8v-U2Oub7CgTo",
  authDomain: "gamepeekr.firebaseapp.com",
  projectId: "gamepeekr",
  storageBucket: "gamepeekr.appspot.com",
  messagingSenderId: "323093182291",
  appId: "1:323093182291:web:4b855c7021ac9fc49fd3a6",
  measurementId: "G-YTV6DFWC6T"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);

export const auth = getAuth();