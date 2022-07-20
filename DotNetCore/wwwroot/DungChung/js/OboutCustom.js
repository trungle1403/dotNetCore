// Custom by NTSOFT
// Created : lytn
// Date : 18/08/2019

if (typeof (oboutGrid) !== "undefined" && typeof (oboutGrid) === "function") {
    $heightManHinhHienTai = window.innerHeight;
    $heightTrangHienTai = document.getElementsByTagName('body')[0].clientHeight;

    oboutGrid.prototype._assignBodyEvents = oboutGrid.prototype.assignBodyEvents;
    oboutGrid.prototype.assignBodyEvents = function () {
        this._assignBodyEvents();
        if (_listGridAutoResize.length > 0) {
            if (_listGridAutoResize.includes(this.ID)) {
                this._autoResizeColumns();
            }
        }
    }

    oboutGrid.prototype._resizeColumn = oboutGrid.prototype.resizeColumn;
    oboutGrid.prototype.resizeColumn = function (columnIndex, amountToResize, keepGridWidth) {
        this._resizeColumn(columnIndex, amountToResize, keepGridWidth || false);
        var width = this._getColumnWidth();
        //width = $('#divload').width();
        if (width > 0) {
            if (this.ScrollWidth == '0px') {
                this.GridMainContainer.style.width = width + 'px';
            } else {
                var scrollWidth = parseInt(this.ScrollWidth);
                if (width < scrollWidth) {
                    this.GridMainContainer.style.width = width + 'px';
                    this.HorizontalScroller.style.display = 'none';
                } else {
                    this.HorizontalScroller.firstChild.firstChild.style.width = width + 'px';
                    this.HorizontalScroller.style.display = 'block';
                }
            }
        }
    }

    oboutGrid.prototype._autoResizeColumns = function () {
        var columnWidths = new Array();
        var body = this.getBodyTableBody();
        for (var i = 0; i < this.ColumnsCollection.length; i++) {
            var headerCell = this.getHeaderCell(i);
            var extraWidth = headerCell.firstChild.offsetWidth - headerCell.firstChild.firstChild.offsetWidth;
            var maxWidth = headerCell.firstChild.firstChild.offsetWidth + extraWidth;
            for (j = 0; j < body.childNodes.length; j++) {
                try {
                    var bodyCell = body.childNodes[j].childNodes[i];
                    var extraWidth = bodyCell.firstChild.offsetWidth - bodyCell.firstChild.firstChild.offsetWidth;
                    var cellWidth = bodyCell.firstChild.firstChild.offsetWidth + extraWidth;

                    if (cellWidth > maxWidth) {
                        maxWidth = cellWidth;
                    }
                } catch (e) {

                }
            }
            columnWidths.push(maxWidth - this.ColumnsCollection[i].Width);
        }

        for (var i = 0; i < columnWidths.length; i++) {
            this.resizeColumn(i, columnWidths[i], false);
        }

        var width = this._getColumnWidth();
        var width = $('#divload').width();
        if ($heightManHinhHienTai < $heightTrangHienTai) {
            width = width - 10;
        }
        this.GridMainContainer.style.width = width + 'px';
    }

    // Lấy tổng chiều dài Grid
    oboutGrid.prototype._getColumnWidth = function () {
        var totalWidth = 0;
        for (var i = 0; i < this.ColumnsCollection.length; i++) {
            if (this.ColumnsCollection[i].Visible) {
                totalWidth += this.ColumnsCollection[i].Width;
            }
        }
        return totalWidth;
    }
}

