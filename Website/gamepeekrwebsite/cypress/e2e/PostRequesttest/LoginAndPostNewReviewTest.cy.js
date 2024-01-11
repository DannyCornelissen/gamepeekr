import { auth } from "../../../src/Utils/firebase.utils"
import APILink from "../../../src/Components/ReusableComponents/Config"
import { signInWithEmailAndPassword } from "firebase/auth"
import { PostData } from "../../../src/Components/DataAccessComponents/GamePeekrAPICalls"

describe('template spec', () => {
  it('passes', () => {
    cy.visit('http://localhost:3000/gamepeekr')

      signInWithEmailAndPassword(auth, 'testUser@test.com', 'password').then(() => {
      const data = {
        id: auth.currentUser.uid,
        userName: auth.currentUser.email
      }
         PostData(data,`${APILink}/api/User`)
    });


      cy.get('#Menu').should('exist')
      .find('li').contains('Add new review').should('exist')
      .click()

      cy.get('#title').type('review of elden ring')
      cy.get('#reviewText').type('This is my review of elden ring its a fun game but the end boss is boring')
      cy.get('#rating').type('7{uparrow}')
      cy.get('#game').type('Elden Ring')
      cy.get('form').submit()

    cy.wait(1000)

    cy.get('table').find('tr')
     .contains('review of elden ring').should('exist').click()

     cy.get('body')
     .contains('This is my review of elden ring its a fun game but the end boss is boring')
     .should('exist')


    
  })
})