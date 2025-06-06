using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU2055B
{
    public class R2220_00_SELECT_PROPOAUT_DB_SELECT_1_Query1 : QueryBasis<R2220_00_SELECT_PROPOAUT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_FONTE
            ,A.NUM_PROPOSTA
            ,VALUE(A.TIPO_COBRANCA, ' ' )
            ,VALUE(A.NUM_RECIBO_CONV,+0)
            ,VALUE(A.IND_TP_RENOVACAO,+0)
            ,VALUE(A.NUM_PROPOSTA_CONV,+0)
            INTO :PROPOAUT-COD-FONTE
            ,:PROPOAUT-NUM-PROPOSTA
            ,:PROPOAUT-TIPO-COBRANCA
            ,:PROPOAUT-NUM-RECIBO-CONV
            ,:PROPOAUT-IND-TP-RENOVACAO
            ,:PROPOAUT-NUM-PROPOSTA-CONV
            FROM SEGUROS.PROPOSTA_AUTO A
            WHERE A.COD_FONTE = :PROPOSTA-COD-FONTE
            AND A.NUM_PROPOSTA = :PROPOSTA-NUM-PROPOSTA
            AND A.SIT_REGISTRO <> '2'
            AND A.NUM_ITEM =
            (SELECT MAX(B.NUM_ITEM)
            FROM SEGUROS.PROPOSTA_AUTO B
            WHERE A.COD_FONTE = B.COD_FONTE
            AND A.NUM_PROPOSTA = B.NUM_PROPOSTA)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_FONTE
											,A.NUM_PROPOSTA
											,VALUE(A.TIPO_COBRANCA
							, ' ' )
											,VALUE(A.NUM_RECIBO_CONV
							,+0)
											,VALUE(A.IND_TP_RENOVACAO
							,+0)
											,VALUE(A.NUM_PROPOSTA_CONV
							,+0)
											FROM SEGUROS.PROPOSTA_AUTO A
											WHERE A.COD_FONTE = '{this.PROPOSTA_COD_FONTE}'
											AND A.NUM_PROPOSTA = '{this.PROPOSTA_NUM_PROPOSTA}'
											AND A.SIT_REGISTRO <> '2'
											AND A.NUM_ITEM =
											(SELECT MAX(B.NUM_ITEM)
											FROM SEGUROS.PROPOSTA_AUTO B
											WHERE A.COD_FONTE = B.COD_FONTE
											AND A.NUM_PROPOSTA = B.NUM_PROPOSTA)";

            return query;
        }
        public string PROPOAUT_COD_FONTE { get; set; }
        public string PROPOAUT_NUM_PROPOSTA { get; set; }
        public string PROPOAUT_TIPO_COBRANCA { get; set; }
        public string PROPOAUT_NUM_RECIBO_CONV { get; set; }
        public string PROPOAUT_IND_TP_RENOVACAO { get; set; }
        public string PROPOAUT_NUM_PROPOSTA_CONV { get; set; }
        public string PROPOSTA_NUM_PROPOSTA { get; set; }
        public string PROPOSTA_COD_FONTE { get; set; }

        public static R2220_00_SELECT_PROPOAUT_DB_SELECT_1_Query1 Execute(R2220_00_SELECT_PROPOAUT_DB_SELECT_1_Query1 r2220_00_SELECT_PROPOAUT_DB_SELECT_1_Query1)
        {
            var ths = r2220_00_SELECT_PROPOAUT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2220_00_SELECT_PROPOAUT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2220_00_SELECT_PROPOAUT_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOAUT_COD_FONTE = result[i++].Value?.ToString();
            dta.PROPOAUT_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOAUT_TIPO_COBRANCA = result[i++].Value?.ToString();
            dta.PROPOAUT_NUM_RECIBO_CONV = result[i++].Value?.ToString();
            dta.PROPOAUT_IND_TP_RENOVACAO = result[i++].Value?.ToString();
            dta.PROPOAUT_NUM_PROPOSTA_CONV = result[i++].Value?.ToString();
            return dta;
        }

    }
}