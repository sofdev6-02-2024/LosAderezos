import PropTypes from 'prop-types';
import Button from './Button';

function CardButton ({ icon: Icon, label, onClick }) {
  return (
    <Button
      onClick={onClick}
      className="flex flex-col items-center justify-center bg-sky-100 w-44 h-44 sm:w-52 sm:h-52 p-6 rounded-[20px] shadow-lg border-4 border-blue-950 
                hover:bg-sky-200 hover:shadow-none active:bg-sky-100 focus:ring-0 focus:outline-none active:ring-0 transition-all"
    >
      <div className="flex flex-col items-center justify-center">
        <Icon className="text-7xl sm:text-7xl mb-2 text-neutral-950" />
        <span className="text-xl sm:text-2xl font-roboto font-bold text-neutral-950 text-center">{label}</span>
      </div>
    </Button>
  );
};

CardButton.propTypes = {
  icon: PropTypes.elementType.isRequired,
  label: PropTypes.string.isRequired,
  onClick: PropTypes.func.isRequired,
};

export default CardButton;