using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0812B
{
    public class R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1 : QueryBasis<R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),+0)
            INTO :WHOST-QTD-RELAT
            FROM SEGUROS.V0RELATORIOS
            WHERE DATA_SOLICITACAO = :V1RELA-DATA-SOL
            AND IDSISTEM = :V1RELA-IDSISTEM
            AND CODRELAT = :V1RELA-CODRELAT
            AND COD_EMPRESA = :V1RELA-COD-EMPR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,+0)
											FROM SEGUROS.V0RELATORIOS
											WHERE DATA_SOLICITACAO = '{this.V1RELA_DATA_SOL}'
											AND IDSISTEM = '{this.V1RELA_IDSISTEM}'
											AND CODRELAT = '{this.V1RELA_CODRELAT}'
											AND COD_EMPRESA = '{this.V1RELA_COD_EMPR}'";

            return query;
        }
        public string WHOST_QTD_RELAT { get; set; }
        public string V1RELA_DATA_SOL { get; set; }
        public string V1RELA_IDSISTEM { get; set; }
        public string V1RELA_CODRELAT { get; set; }
        public string V1RELA_COD_EMPR { get; set; }

        public static R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1 Execute(R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1 r0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1)
        {
            var ths = r0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0600_00_SELECT_RELAT_CONG_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_QTD_RELAT = result[i++].Value?.ToString();
            return dta;
        }

    }
}