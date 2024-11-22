import { List } from "flowbite-react";
import PropTypes from "prop-types";

function GenericList({ items, renderItem, className }) {
  return (
    <List unstyled className={className}>
      {items.map((item, index) => (
        <List.Item key={index} className="py-1">
          {renderItem(item, index)}
        </List.Item>
      ))}
    </List>
  );
}

GenericList.propTypes = {
  items: PropTypes.array.isRequired,
  renderItem: PropTypes.func.isRequired,
  className: PropTypes.string
};

export default GenericList;
