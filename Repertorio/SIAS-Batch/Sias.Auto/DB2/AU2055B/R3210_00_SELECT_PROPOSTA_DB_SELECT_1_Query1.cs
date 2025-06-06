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
    public class R3210_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<R3210_00_SELECT_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.SIT_REGISTRO ,
            B.TIPO_COBRANCA ,
            C.COD_CONVENIO
            INTO :PROPOSTA-SIT-REGISTRO ,
            :PROPCOBR-TIPO-COBRANCA ,
            :MOVDEBCE-COD-CONVENIO
            FROM SEGUROS.PROPOSTAS A ,
            SEGUROS.PROPOSTA_COBRANCA B ,
            SEGUROS.MOVTO_DEBITOCC_CEF C
            WHERE A.COD_FONTE = :PROPOSTA-COD-FONTE
            AND A.NUM_PROPOSTA = :PROPOSTA-NUM-PROPOSTA
            AND A.COD_FONTE = B.COD_FONTE
            AND A.NUM_PROPOSTA = B.NUM_PROPOSTA
            AND B.COD_FONTE = C.NUM_APOLICE
            AND B.NUM_PROPOSTA = C.NUM_ENDOSSO
            AND C.STATUS_CARTAO = 'A'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.SIT_REGISTRO 
							,
											B.TIPO_COBRANCA 
							,
											C.COD_CONVENIO
											FROM SEGUROS.PROPOSTAS A 
							,
											SEGUROS.PROPOSTA_COBRANCA B 
							,
											SEGUROS.MOVTO_DEBITOCC_CEF C
											WHERE A.COD_FONTE = '{this.PROPOSTA_COD_FONTE}'
											AND A.NUM_PROPOSTA = '{this.PROPOSTA_NUM_PROPOSTA}'
											AND A.COD_FONTE = B.COD_FONTE
											AND A.NUM_PROPOSTA = B.NUM_PROPOSTA
											AND B.COD_FONTE = C.NUM_APOLICE
											AND B.NUM_PROPOSTA = C.NUM_ENDOSSO
											AND C.STATUS_CARTAO = 'A'";

            return query;
        }
        public string PROPOSTA_SIT_REGISTRO { get; set; }
        public string PROPCOBR_TIPO_COBRANCA { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string PROPOSTA_NUM_PROPOSTA { get; set; }
        public string PROPOSTA_COD_FONTE { get; set; }

        public static R3210_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 Execute(R3210_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 r3210_00_SELECT_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = r3210_00_SELECT_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3210_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3210_00_SELECT_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOSTA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.PROPCOBR_TIPO_COBRANCA = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_CONVENIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}