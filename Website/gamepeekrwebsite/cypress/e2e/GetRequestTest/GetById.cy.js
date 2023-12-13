describe('template spec', () => {
  it('passes', () => {
    cy.visit('http://localhost:3000/')
    cy.wait(1000)
    cy.get('table').should('exist').find('tr')
    .contains('Elden Ring Review').should('exist')
    .click()
    
    cy.get('body')
    .contains('In the 87 hours that it took me to beat Elden Ring, I was put through an absolute wringer of emotion: Anger as I was beaten down by its toughest challenges, exhilaration when I finally overcame them, and a fair amount of sorrow for the mountains of exp I lost along the way to some of the toughest boss encounters FromSoftware has ever conceived. But more than anything else I was in near-constant awe – from the many absolutely jaw-dropping vistas, the sheer scope of an absolutely enormous world, the frequently harrowing enemies, and the way in which Elden Ring nearly always rewarded my curiosity with either an interesting encounter, a valuable reward, or something even greater. FromSoftware takes the ball that The Legend of Zelda: Breath of the Wild got rolling and runs with it, creating a fascinating and dense open world about freedom and exploration above all else, while also somehow managing to seamlessly weave a full-on Dark Souls game into the middle of it. It shouldn’t be a surprise to anyone that Elden Ring ended up as one of the most unforgettable gaming experiences I’ve ever had.')
    .should('exist')

  })
})