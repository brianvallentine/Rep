using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.RE0002S
{
    public class R1800_SELECT_MRAPOITE_DB_SELECT_1_Query1 : QueryBasis<R1800_SELECT_MRAPOITE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(PCT_DESC_FIDEL,+0)
            INTO :MRAPOITE-PCT-DESC-FIDEL
            FROM SEGUROS.MR_APOLICE_ITEM
            WHERE NUM_APOLICE = :MRAPOITE-NUM-APOLICE
            AND NUM_ENDOSSO = :MRAPOITE-NUM-ENDOSSO
            AND NUM_ITEM = :MRAPOITE-NUM-ITEM
            AND COD_PRODUTO = :MRPROCOB-COD-PRODUTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(PCT_DESC_FIDEL
							,+0)
											FROM SEGUROS.MR_APOLICE_ITEM
											WHERE NUM_APOLICE = '{this.MRAPOITE_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.MRAPOITE_NUM_ENDOSSO}'
											AND NUM_ITEM = '{this.MRAPOITE_NUM_ITEM}'
											AND COD_PRODUTO = '{this.MRPROCOB_COD_PRODUTO}'
											WITH UR";

            return query;
        }
        public string MRAPOITE_PCT_DESC_FIDEL { get; set; }
        public string MRAPOITE_NUM_APOLICE { get; set; }
        public string MRAPOITE_NUM_ENDOSSO { get; set; }
        public string MRPROCOB_COD_PRODUTO { get; set; }
        public string MRAPOITE_NUM_ITEM { get; set; }

        public static R1800_SELECT_MRAPOITE_DB_SELECT_1_Query1 Execute(R1800_SELECT_MRAPOITE_DB_SELECT_1_Query1 r1800_SELECT_MRAPOITE_DB_SELECT_1_Query1)
        {
            var ths = r1800_SELECT_MRAPOITE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1800_SELECT_MRAPOITE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1800_SELECT_MRAPOITE_DB_SELECT_1_Query1();
            var i = 0;
            dta.MRAPOITE_PCT_DESC_FIDEL = result[i++].Value?.ToString();
            return dta;
        }

    }
}