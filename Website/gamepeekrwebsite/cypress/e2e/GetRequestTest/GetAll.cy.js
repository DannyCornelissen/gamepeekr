describe('template spec', () => {
  it('passes',  () => {
    cy.visit('http://localhost:3000/')
    cy.wait(1000)
    cy.get('table').should('exist').find('td')
    .first()
    .should('have.text', 'string')

    cy.get('table').find('tr')
    .contains('review of elden ring').should('exist')

  })
})