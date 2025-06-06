using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7028B
{
    public class R1020_00_SELECT_COBMENVG_DB_SELECT_1_Query1 : QueryBasis<R1020_00_SELECT_COBMENVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :HOST-COUNT1
            FROM SEGUROS.COBRANCA_MENS_VGAP
            WHERE IDFORM = 'A4'
            AND NUM_APOLICE = :WHOST-NRAPOLICE
            AND CODSUBES = :PROPOFID-COD-PRODUTO-SIVPF
            AND COD_OPERACAO = 3
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.COBRANCA_MENS_VGAP
											WHERE IDFORM = 'A4'
											AND NUM_APOLICE = '{this.WHOST_NRAPOLICE}'
											AND CODSUBES = '{this.PROPOFID_COD_PRODUTO_SIVPF}'
											AND COD_OPERACAO = 3";

            return query;
        }
        public string HOST_COUNT1 { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string WHOST_NRAPOLICE { get; set; }

        public static R1020_00_SELECT_COBMENVG_DB_SELECT_1_Query1 Execute(R1020_00_SELECT_COBMENVG_DB_SELECT_1_Query1 r1020_00_SELECT_COBMENVG_DB_SELECT_1_Query1)
        {
            var ths = r1020_00_SELECT_COBMENVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1020_00_SELECT_COBMENVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1020_00_SELECT_COBMENVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_COUNT1 = result[i++].Value?.ToString();
            return dta;
        }

    }
}