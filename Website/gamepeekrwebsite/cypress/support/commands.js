import { signInWithEmailAndPassword } from "firebase/auth"
import { PostData } from "../../src/Components/DataAccessComponents/GamePeekrAPICalls";

Cypress.Commands.add('signInWithEmailAndPassword', (auth, email, password) => {
    return cy.wrap(signInWithEmailAndPassword(auth, email, password));
  });

  Cypress.Commands.add('PostData', (data, apiLink) => {
    return new Cypress.Promise((resolve) => {
      PostData(data, apiLink).then((result) => {
        resolve(result);
      });
    });
  });





