using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0100S
{
    public class M_0300_CONTABIL_NOVA_DB_SELECT_1_Query1 : QueryBasis<M_0300_CONTABIL_NOVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_OPERACAO, VLIOCC
            INTO :VLOPER-FIL, :VLIOCC-FIL
            FROM SEGUROS.V0SALCONTABAZFIL
            WHERE NUM_APOLICE = :NUM-APOLICE
            AND COD_FONTE = :FONTE
            AND DTMOVTO = :DTMOVTO
            AND COD_SUBGRUPO = :COD-SUBGRUPO
            AND COD_OPERACAO = :CODOPER
            AND NUM_FATURA IS NULL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VAL_OPERACAO
							, VLIOCC
											FROM SEGUROS.V0SALCONTABAZFIL
											WHERE NUM_APOLICE = '{this.NUM_APOLICE}'
											AND COD_FONTE = '{this.FONTE}'
											AND DTMOVTO = '{this.DTMOVTO}'
											AND COD_SUBGRUPO = '{this.COD_SUBGRUPO}'
											AND COD_OPERACAO = '{this.CODOPER}'
											AND NUM_FATURA IS NULL";

            return query;
        }
        public string VLOPER_FIL { get; set; }
        public string VLIOCC_FIL { get; set; }
        public string COD_SUBGRUPO { get; set; }
        public string NUM_APOLICE { get; set; }
        public string DTMOVTO { get; set; }
        public string CODOPER { get; set; }
        public string FONTE { get; set; }

        public static M_0300_CONTABIL_NOVA_DB_SELECT_1_Query1 Execute(M_0300_CONTABIL_NOVA_DB_SELECT_1_Query1 m_0300_CONTABIL_NOVA_DB_SELECT_1_Query1)
        {
            var ths = m_0300_CONTABIL_NOVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0300_CONTABIL_NOVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0300_CONTABIL_NOVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.VLOPER_FIL = result[i++].Value?.ToString();
            dta.VLIOCC_FIL = result[i++].Value?.ToString();
            return dta;
        }

    }
}