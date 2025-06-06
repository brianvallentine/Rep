using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0120B
{
    public class M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1 : QueryBasis<M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT VLCRUZAD
            INTO :MOEDA-VLCRUZADO
            FROM SEGUROS.V1MOEDA
            WHERE CODUNIMO = :HISTSEGVG-COD-MOEDA-IMP
            AND DTINIVIG <= :HISTSEGVG-DATA-MOV
            AND DTTERVIG >= :HISTSEGVG-DATA-MOV
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLCRUZAD
											FROM SEGUROS.V1MOEDA
											WHERE CODUNIMO = '{this.HISTSEGVG_COD_MOEDA_IMP}'
											AND DTINIVIG <= '{this.HISTSEGVG_DATA_MOV}'
											AND DTTERVIG >= '{this.HISTSEGVG_DATA_MOV}'";

            return query;
        }
        public string MOEDA_VLCRUZADO { get; set; }
        public string HISTSEGVG_COD_MOEDA_IMP { get; set; }
        public string HISTSEGVG_DATA_MOV { get; set; }

        public static M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1 Execute(M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1 m_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1)
        {
            var ths = m_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOEDA_VLCRUZADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}