using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0714B
{
    public class R0220_00_LER_TERMO_DB_SELECT_1_Query1 : QueryBasis<R0220_00_LER_TERMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            COD_SUBGRUPO,
            DATA_ADESAO
            INTO :TERMOADE-NUM-APOLICE ,
            :TERMOADE-COD-SUBGRUPO,
            :TERMOADE-DATA-ADESAO
            FROM SEGUROS.TERMO_ADESAO
            WHERE NUM_TERMO = :TERMOADE-NUM-TERMO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											COD_SUBGRUPO
							,
											DATA_ADESAO
											FROM SEGUROS.TERMO_ADESAO
											WHERE NUM_TERMO = '{this.TERMOADE_NUM_TERMO}'
											WITH UR";

            return query;
        }
        public string TERMOADE_NUM_APOLICE { get; set; }
        public string TERMOADE_COD_SUBGRUPO { get; set; }
        public string TERMOADE_DATA_ADESAO { get; set; }
        public string TERMOADE_NUM_TERMO { get; set; }

        public static R0220_00_LER_TERMO_DB_SELECT_1_Query1 Execute(R0220_00_LER_TERMO_DB_SELECT_1_Query1 r0220_00_LER_TERMO_DB_SELECT_1_Query1)
        {
            var ths = r0220_00_LER_TERMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0220_00_LER_TERMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0220_00_LER_TERMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.TERMOADE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.TERMOADE_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.TERMOADE_DATA_ADESAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}