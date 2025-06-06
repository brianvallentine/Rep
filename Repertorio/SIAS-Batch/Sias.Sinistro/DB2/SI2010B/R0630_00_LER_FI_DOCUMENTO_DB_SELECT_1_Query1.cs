using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI2010B
{
    public class R0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1 : QueryBasis<R0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_DOC_FISCAL
            INTO :FIPADOFI-NUM-DOC-FISCAL
            FROM SEGUROS.FI_PAGA_DOC_FISCAL
            WHERE NUM_DOCF_INTERNO = :FIPADOFI-NUM-DOCF-INTERNO
            AND COD_FORNECEDOR = :FIPADOFI-COD-FORNECEDOR
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_DOC_FISCAL
											FROM SEGUROS.FI_PAGA_DOC_FISCAL
											WHERE NUM_DOCF_INTERNO = '{this.FIPADOFI_NUM_DOCF_INTERNO}'
											AND COD_FORNECEDOR = '{this.FIPADOFI_COD_FORNECEDOR}'
											WITH UR";

            return query;
        }
        public string FIPADOFI_NUM_DOC_FISCAL { get; set; }
        public string FIPADOFI_NUM_DOCF_INTERNO { get; set; }
        public string FIPADOFI_COD_FORNECEDOR { get; set; }

        public static R0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1 Execute(R0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1 r0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1)
        {
            var ths = r0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0630_00_LER_FI_DOCUMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.FIPADOFI_NUM_DOC_FISCAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}