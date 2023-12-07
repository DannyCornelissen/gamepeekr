import { auth } from "../../Utils/firebase.utils";
import {signInWithPopup, GoogleAuthProvider} from "firebase/auth";
import { PostData } from "../DataAccessComponents/GamePeekrAPICalls";
import APILink from "../ReusableComponents/Config";
    // Initialize Firebase Auth provider
    const provider = new GoogleAuthProvider();
  
       // whenever a user interacts with the provider, we force them to select an account
      provider.setCustomParameters({   
    prompt : "select_account"
    });



   
    
    const logGoogleUser = async () => {
        
            await signInWithPopup(auth, provider);
            const data = {
                id: auth.currentUser.uid,
                userName: auth.currentUser.displayName
              };
            PostData(data,`${APILink}/api/User`)
        }

    export default logGoogleUser;