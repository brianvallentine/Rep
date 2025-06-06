using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0972B
{
    public class R7050_00_RECUPERA_CONTROLE_DB_SELECT_1_Query1 : QueryBasis<R7050_00_RECUPERA_CONTROLE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_OCORR_MOVTO
            , SEQ_CONTROL_CARTAO
            INTO :GE407-NUM-OCORR-MOVTO
            , :GE407-SEQ-CONTROL-CARTAO
            FROM SEGUROS.GE_CONTROLE_CARTAO_CIELO
            WHERE NUM_CERTIFICADO = :GE407-NUM-CERTIFICADO
            AND NUM_PARCELA = :GE407-NUM-PARCELA
            AND STA_REGISTRO IN ( 'H' , 'A' )
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_OCORR_MOVTO
											, SEQ_CONTROL_CARTAO
											FROM SEGUROS.GE_CONTROLE_CARTAO_CIELO
											WHERE NUM_CERTIFICADO = '{this.GE407_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.GE407_NUM_PARCELA}'
											AND STA_REGISTRO IN ( 'H' 
							, 'A' )
											WITH UR";

            return query;
        }
        public string GE407_NUM_OCORR_MOVTO { get; set; }
        public string GE407_SEQ_CONTROL_CARTAO { get; set; }
        public string GE407_NUM_CERTIFICADO { get; set; }
        public string GE407_NUM_PARCELA { get; set; }

        public static R7050_00_RECUPERA_CONTROLE_DB_SELECT_1_Query1 Execute(R7050_00_RECUPERA_CONTROLE_DB_SELECT_1_Query1 r7050_00_RECUPERA_CONTROLE_DB_SELECT_1_Query1)
        {
            var ths = r7050_00_RECUPERA_CONTROLE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7050_00_RECUPERA_CONTROLE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7050_00_RECUPERA_CONTROLE_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE407_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            dta.GE407_SEQ_CONTROL_CARTAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}