import PropTypes from "prop-types";
import { CiSearch } from "react-icons/ci";
import Button from "./Button";
import { useEffect, useState } from "react";

export default function SearchBar({ onSearch, placeholder, items }) {
  const [text, setText] = useState("");
  const [itemsList, setItemsList] = useState([]);
  const [highlightedIndex, setHighlightedIndex] = useState(-1);

  useEffect(() => {
    if (!items) {
      setItemsList([]);
    } else {
      setItemsList(items);
    }
  }, [items]);
  const handleKeyPress = (event) => {
    if (event.key === "Enter") {
      onSearch(text);
      setText("");
    }
  };

  const handleClick = () => {
    onSearch(text);
    setText("");
  };

  const handleChange = (value) => {
    setText(value);
    if (items) {
      const filtered = items.filter((item) =>
        item.toLowerCase().includes(value.toLowerCase())
      );
      setItemsList(filtered);
    }
  };

  return (
    <div className="relative">
      <div className="flex justify-between items-center border-2 border-[#E5E5E5] bg-white rounded-[10px] w-full p-2">
        <input
          type="text"
          placeholder={placeholder ? placeholder : "Buscar..."}
          value={text}
          onChange={(e) => {
            handleChange(e.target.value);
          }}
          onKeyUp={handleKeyPress}
          className="flex-grow p-2 border-none focus:ring-0"
        />
        <Button onClick={handleClick}>
          <CiSearch className="size-[20px]" />
        </Button>
      </div>
      {text.trim() && itemsList.length > 0 && (
        <ul className="absolute top-full left-0 w-full bg-white border border-neutral-200 rounded-lg shadow-md max-h-40 overflow-y-auto z-10">
          {itemsList.map((item, index) => (
            <li
              key={index}
              className={`px-4 py-2 cursor-pointer ${
                highlightedIndex === index
                  ? "bg-neutral-200"
                  : "hover:bg-neutral-100"
              }`}
              onClick={() => {
                setText(item);
                handleClick();
              }}
              onMouseEnter={() => setHighlightedIndex(index)}
            >
              {item}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

SearchBar.propTypes = {
  onSearch: PropTypes.func,
  placeholder: PropTypes.string,
  items: PropTypes.array,
};
