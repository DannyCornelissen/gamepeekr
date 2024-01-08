import { initializeApp } from "firebase/app";
import { getAuth} from "firebase/auth";

const firebaseConfig = {
  apiKey: "AIzaSyAfCSI4340wyHX78Lxudw8v-U2Oub7CgTo",
  authDomain: "gamepeekr.firebaseapp.com",
  projectId: "gamepeekr",
  storageBucket: "gamepeekr.appspot.com",
  messagingSenderId: "323093182291",
  appId: "1:323093182291:web:4b855c7021ac9fc49fd3a6",
  measurementId: "G-YTV6DFWC6T"
};

const app = initializeApp(firebaseConfig);
const auth = getAuth();

function checkAuthUser() {
    return new Promise((resolve, reject) => {
        const unsubscribe = auth.onAuthStateChanged((user) => {
            unsubscribe();
            if (user) {
                resolve(user);
            } else {
                resolve(null);
            }
        }, reject);
    });
}

export {auth, checkAuthUser}