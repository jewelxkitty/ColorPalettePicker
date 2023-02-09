let allColorBoxes = [
  '#D61355',
  '#F94A29',
  '#FCE22A',
  '#30E3DF'
];

const setColorBoxColor = (boxId, newColor) => {
  allColorBoxes[boxId] = newColor;
  showLatestColorBoxes();
};

const showLatestColorBoxes = () => {
  const content = document.querySelector('#content');
  content.innerHTML = '';
  allColorBoxes.forEach((colorBox, idx) => {
    addColorBox(colorBox, content, idx);
  });
};

const addColorBox = (hexColor, parent, boxId) => {
  const newBox = document.createElement('section');
  newBox.classList.add('color-box');
  const newSwatch = document.createElement('div');
  newSwatch.classList.add('color-swatch');
  newBox.appendChild(newSwatch);
  const colorTextBox = document.createElement('input');
  colorTextBox.classList.add('color-code');
  newBox.appendChild(colorTextBox);
  newSwatch.style.backgroundColor = hexColor;
  colorTextBox.value= hexColor;
  // colorTextBox.addEventListener('input', (event)=>{
  //   const newValue = event.target.value;
  //   console.log(newValue);
  // });
  const newButton = document.createElement('button');
  newButton.innerHTML= 'Change color.';
  newBox.appendChild(newButton);
  newButton.addEventListener('click', () => {
    console.log(colorTextBox.value);
    allColorBoxes[boxId] = colorTextBox.value;
    showLatestColorBoxes(); 
  });
  parent.appendChild(newBox);
};

const loadColors = async () => {
  const fetchResult = await fetch('http://localhost:5216/palette');
  const data = await fetchResult.json();
  const justHexCodes = data.map((hexObject) => {
    return hexObject.hexCode;
  });
  allColorBoxes = justHexCodes;
  showLatestColorBoxes();
};
const saveColors = async () => {
  const options = {
    method: 'POST', 
    body: JSON.stringify(allColorBoxes),
    headers: {'Content-Type': 'application/json'}
  };
  const postResult = await fetch('http://localhost:5216/palette', options);
  const data = await postResult.json();
  const justHexCodes = data.map((hexObject) => {
    return hexObject.hexCode;
  });
  allColorBoxes = justHexCodes;
  showLatestColorBoxes();
};
window.onload = () => {
  showLatestColorBoxes();
}