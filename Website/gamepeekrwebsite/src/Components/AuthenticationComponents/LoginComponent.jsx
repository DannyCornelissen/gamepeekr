import { auth } from "../../Utils/firebase.utils";
import {signInWithPopup, GoogleAuthProvider} from "firebase/auth";


    // Initialize Firebase Auth provider
    const provider = new GoogleAuthProvider();
  
       // whenever a user interacts with the provider, we force them to select an account
      provider.setCustomParameters({   
    prompt : "select_account"
    });

    const logGoogleUser = async () => {
            const response = await signInWithPopup(auth, provider);
            console.log(auth.currentUser);

        }

    export default logGoogleUser;