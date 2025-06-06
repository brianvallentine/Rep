using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0135B
{
    public class R1330_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 : QueryBasis<R1330_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            NUM_ENDOSSO,
            NUM_PARCELA,
            SITUACAO_COBRANCA
            INTO :MOVDEBCE-NUM-APOLICE,
            :MOVDEBCE-NUM-ENDOSSO,
            :MOVDEBCE-NUM-PARCELA,
            :MOVDEBCE-SITUACAO-COBRANCA
            FROM SEGUROS.MOVTO_DEBITOCC_CEF MO1
            WHERE MO1.COD_EMPRESA = 0
            AND MO1.NUM_APOLICE = :ENDOSSOS-NUM-APOLICE
            AND MO1.NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO
            AND MO1.TIMESTAMP =
            (SELECT MAX(MO2.TIMESTAMP)
            FROM SEGUROS.MOVTO_DEBITOCC_CEF MO2
            WHERE MO2.COD_EMPRESA = MO1.COD_EMPRESA
            AND MO2.NUM_APOLICE = MO1.NUM_APOLICE
            AND MO2.NUM_ENDOSSO = MO1.NUM_ENDOSSO
            AND MO2.NUM_PARCELA = MO1.NUM_PARCELA )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											NUM_ENDOSSO
							,
											NUM_PARCELA
							,
											SITUACAO_COBRANCA
											FROM SEGUROS.MOVTO_DEBITOCC_CEF MO1
											WHERE MO1.COD_EMPRESA = 0
											AND MO1.NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											AND MO1.NUM_ENDOSSO = '{this.ENDOSSOS_NUM_ENDOSSO}'
											AND MO1.TIMESTAMP =
											(SELECT MAX(MO2.TIMESTAMP)
											FROM SEGUROS.MOVTO_DEBITOCC_CEF MO2
											WHERE MO2.COD_EMPRESA = MO1.COD_EMPRESA
											AND MO2.NUM_APOLICE = MO1.NUM_APOLICE
											AND MO2.NUM_ENDOSSO = MO1.NUM_ENDOSSO
											AND MO2.NUM_PARCELA = MO1.NUM_PARCELA )";

            return query;
        }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }

        public static R1330_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 Execute(R1330_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 r1330_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1)
        {
            var ths = r1330_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1330_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1330_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVDEBCE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_PARCELA = result[i++].Value?.ToString();
            dta.MOVDEBCE_SITUACAO_COBRANCA = result[i++].Value?.ToString();
            return dta;
        }

    }
}