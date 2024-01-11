describe('template spec', () => {
  it('passes',  () => {
    cy.visit('http://localhost:3000/gamepeekr')
    cy.wait(1000)
    cy.get('table').should('exist').find('tr')
    .contains('review of elden ring').should('exist')
    .click()
    
    cy.get('body')
    .contains('This is my review of elden ring its a fun game but the end boss is boring')
    .should('exist')

  })
})