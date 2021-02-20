"use strict";
var KTDatatablesSearchOptionsAdvancedSearch = function() {

	$.fn.dataTable.Api.register('column().title()', function() {
		return $(this.header()).text().trim();
	});

	var initTable1 = function() {
		// begin first table
		var table = $('#kt_table_1').DataTable({
			responsive: true,
			// Pagination settings
			dom: `<'row'<'col-sm-12'tr>>
			<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'lp>>`,
			// read more: https://datatables.net/examples/basic_init/dom.html

			lengthMenu: [5, 10, 25, 50],

			pageLength: 10,

			language: {
				'lengthMenu': 'Display _MENU_',
			},

			searchDelay: 500,
			processing: true,
			serverSide: true,
			ajax: {
				url: '/Auto/GetAutoManufacturerU',
				type: 'POST',
				
				data: {
					// parameters for custom backend script demo
					columnsDef: [
						'autoManufacturerName','Actions'],
				},
				dataSrc: function (response) {
					return response.result;
			}
			},
			columns: [
				{ data: 'autoManufacturerName'},
				{ data: 'id', responsivePriority: -1, width: 120},
			],

			initComplete: function() {
				this.api().columns().every(function() {
					var column = this;

					//switch (column.title()) {
					//	case 'Country':
					//		column.data().unique().sort().each(function(d, j) {
					//			$('.kt-input[data-col-index="2"]').append('<option value="' + d + '">' + d + '</option>');
					//		});
					//		break;

					//	case 'Status':
					//		var status = {
					//			1: {'title': 'Pending', 'class': 'kt-badge--brand'},
					//			2: {'title': 'Delivered', 'class': ' kt-badge--danger'},
					//			3: {'title': 'Canceled', 'class': ' kt-badge--primary'},
					//			4: {'title': 'Success', 'class': ' kt-badge--success'},
					//			5: {'title': 'Info', 'class': ' kt-badge--info'},
					//			6: {'title': 'Danger', 'class': ' kt-badge--danger'},
					//			7: {'title': 'Warning', 'class': ' kt-badge--warning'},
					//		};
					//		column.data().unique().sort().each(function(d, j) {
					//			$('.kt-input[data-col-index="6"]').append('<option value="' + d + '">' + status[d].title + '</option>');
					//		});
					//		break;

					//	case 'Type':
					//		var status = {
					//			1: {'title': 'Online', 'state': 'danger'},
					//			2: {'title': 'Retail', 'state': 'primary'},
					//			3: {'title': 'Direct', 'state': 'success'},
					//		};
					//		column.data().unique().sort().each(function(d, j) {
					//			$('.kt-input[data-col-index="7"]').append('<option value="' + d + '">' + status[d].title + '</option>');
					//		});
					//		break;
					//}
				});
			},

			columnDefs: [
				{
					targets: -1,
					title: 'Actions',
					orderable: false,
					render: function (data, type, full, meta) {
						var id = data;
						return '<button title="View Details" type="button" class="btnView btn btn-outline-hover-dark btn-sm btn-icon"  data-id="@item.Id"><i class="la la-eye"></i></button><button title="Edit" type="button" class="btnEdit btn btn-outline-hover-dark btn-sm btn-icon" onclick=autoManufacturer.editAutoManufactuer('+ data +')><i class="la la-edit"></i></button><button title="Delete" type="button" class="btnDelete btn btn-outline-hover-danger btn-sm btn-icon" onclick= autoManufacturer.deleteAutoManufactuer('+ data +')><i class="la la-trash"></i></button>';
					},
				},
				//{
				//	targets: 6,
				//	render: function(data, type, full, meta) {
				//		var status = {
				//			1: {'title': 'Pending', 'class': 'kt-badge--brand'},
				//			2: {'title': 'Delivered', 'class': ' kt-badge--danger'},
				//			3: {'title': 'Canceled', 'class': ' kt-badge--primary'},
				//			4: {'title': 'Success', 'class': ' kt-badge--success'},
				//			5: {'title': 'Info', 'class': ' kt-badge--info'},
				//			6: {'title': 'Danger', 'class': ' kt-badge--danger'},
				//			7: {'title': 'Warning', 'class': ' kt-badge--warning'},
				//		};
				//		if (typeof status[data] === 'undefined') {
				//			return data;
				//		}
				//		return '<span class="kt-badge ' + status[data].class + ' kt-badge--inline kt-badge--pill">' + status[data].title + '</span>';
				//	},
				//},
				//{
				//	targets: 7,
				//	render: function(data, type, full, meta) {
				//		var status = {
				//			1: {'title': 'Online', 'state': 'danger'},
				//			2: {'title': 'Retail', 'state': 'primary'},
				//			3: {'title': 'Direct', 'state': 'success'},
				//		};
				//		if (typeof status[data] === 'undefined') {
				//			return data;
				//		}
				//		return '<span class="kt-badge kt-badge--' + status[data].state + ' kt-badge--dot"></span>&nbsp;' +
				//			'<span class="kt-font-bold kt-font-' + status[data].state + '">' + status[data].title + '</span>';
				//	},
				//},
			],
		});

		//var filter = function() {
		//	var val = $.fn.dataTable.util.escapeRegex($(this).val());
		//	table.column($(this).data('col-index')).search(val ? val : '', false, false).draw();
		//};

		//var asdasd = function(value, index) {
		//	var val = $.fn.dataTable.util.escapeRegex(value);
		//	table.column(index).search(val ? val : '', false, true);
		//};

		//$('#kt_search').on('click', function(e) {
		//	e.preventDefault();
		//	var params = {};
		//	$('.kt-input').each(function() {
		//		var i = $(this).data('col-index');
		//		if (params[i]) {
		//			params[i] += '|' + $(this).val();
		//		}
		//		else {
		//			params[i] = $(this).val();
		//		}
		//	});
		//	$.each(params, function(i, val) {
		//		// apply search params to datatable
		//		table.column(i).search(val ? val : '', false, false);
		//	});
		//	table.table().draw();
		//});

		//$('#kt_reset').on('click', function(e) {
		//	e.preventDefault();
		//	$('.kt-input').each(function() {
		//		$(this).val('');
		//		table.column($(this).data('col-index')).search('', false, false);
		//	});
		//	table.table().draw();
		//});

		//$('#kt_datepicker').datepicker({
		//	todayHighlight: true,
		//	templates: {
		//		leftArrow: '<i class="la la-angle-left"></i>',
		//		rightArrow: '<i class="la la-angle-right"></i>',
		//	},
		//});

	};

	return {

		//main function to initiate the module
		init: function() {
			initTable1();
		},

	};

}();

jQuery(document).ready(function() {
	KTDatatablesSearchOptionsAdvancedSearch.init();
});