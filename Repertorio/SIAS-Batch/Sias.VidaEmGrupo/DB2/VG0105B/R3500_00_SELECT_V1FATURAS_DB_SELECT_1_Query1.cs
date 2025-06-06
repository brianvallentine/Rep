using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0105B
{
    public class R3500_00_SELECT_V1FATURAS_DB_SELECT_1_Query1 : QueryBasis<R3500_00_SELECT_V1FATURAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA ,
            DATA_TERVIGENCIA
            INTO :V1FATR-DATA-INIVIG ,
            :V1FATR-DATA-TERVIG
            FROM SEGUROS.V1FATURAS
            WHERE NUM_APOLICE = :W1SOLF-NUM-APOL
            AND COD_SUBGRUPO = :W1SOLF-COD-SUBG
            AND NUM_FATURA = :W1SOLF-NUM-FAT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA 
							,
											DATA_TERVIGENCIA
											FROM SEGUROS.V1FATURAS
											WHERE NUM_APOLICE = '{this.W1SOLF_NUM_APOL}'
											AND COD_SUBGRUPO = '{this.W1SOLF_COD_SUBG}'
											AND NUM_FATURA = '{this.W1SOLF_NUM_FAT}'";

            return query;
        }
        public string V1FATR_DATA_INIVIG { get; set; }
        public string V1FATR_DATA_TERVIG { get; set; }
        public string W1SOLF_NUM_APOL { get; set; }
        public string W1SOLF_COD_SUBG { get; set; }
        public string W1SOLF_NUM_FAT { get; set; }

        public static R3500_00_SELECT_V1FATURAS_DB_SELECT_1_Query1 Execute(R3500_00_SELECT_V1FATURAS_DB_SELECT_1_Query1 r3500_00_SELECT_V1FATURAS_DB_SELECT_1_Query1)
        {
            var ths = r3500_00_SELECT_V1FATURAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3500_00_SELECT_V1FATURAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3500_00_SELECT_V1FATURAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1FATR_DATA_INIVIG = result[i++].Value?.ToString();
            dta.V1FATR_DATA_TERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}