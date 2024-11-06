import PropTypes from "prop-types";

function BranchItem({ branch }) {
  return (
    <div className="flex items-center border border-neutral-950 p-4 rounded-lg">
      <div className="flex-1">
        <p className="text-xl font-roboto font-medium text-neutral-950">{branch.branchName}</p>
        <p className="text-sm font-roboto font-normal text-neutral-950">{branch.address}</p>
      </div>
      <div>
        <p className="text-2xl font-roboto font-bold text-neutral-950">{branch.quantity}</p>
      </div>
    </div>
  );
}

BranchItem.propTypes = {
  branch: PropTypes.shape({
    branchName: PropTypes.string.isRequired,
    address: PropTypes.string.isRequired,
    quantity: PropTypes.number.isRequired,
  }).isRequired,
};

export default BranchItem;
