using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R1420_VERIFICA_MATRIZ_DB_SELECT_1_Query1 : QueryBasis<R1420_VERIFICA_MATRIZ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IND_RET_SUBSCRICAO
            , PCT_AGRAVO
            , VLR_PRM_SEM_AGR
            INTO :GE406-IND-RET-SUBSCRICAO :VIND-RET-SUBSCRICAO
            , :GE406-PCT-AGRAVO :VIND-PCT-AGRAVO
            , :GE406-VLR-PRM-SEM-AGR :VIND-VLR-PRM-SEM-AGR
            FROM SEGUROS.GE_RETENCAO_PROPOSTA
            WHERE NUM_CERTIFICADO = :PROPOFID-NUM-PROPOSTA-SIVPF
            AND IND_PROCESSAMENTO = 'D'
            AND COD_USUARIO = 'VA0600B'
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT IND_RET_SUBSCRICAO
											, PCT_AGRAVO
											, VLR_PRM_SEM_AGR
											FROM SEGUROS.GE_RETENCAO_PROPOSTA
											WHERE NUM_CERTIFICADO = '{this.PROPOFID_NUM_PROPOSTA_SIVPF}'
											AND IND_PROCESSAMENTO = 'D'
											AND COD_USUARIO = 'VA0600B'";

            return query;
        }
        public string GE406_IND_RET_SUBSCRICAO { get; set; }
        public string VIND_RET_SUBSCRICAO { get; set; }
        public string GE406_PCT_AGRAVO { get; set; }
        public string VIND_PCT_AGRAVO { get; set; }
        public string GE406_VLR_PRM_SEM_AGR { get; set; }
        public string VIND_VLR_PRM_SEM_AGR { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static R1420_VERIFICA_MATRIZ_DB_SELECT_1_Query1 Execute(R1420_VERIFICA_MATRIZ_DB_SELECT_1_Query1 r1420_VERIFICA_MATRIZ_DB_SELECT_1_Query1)
        {
            var ths = r1420_VERIFICA_MATRIZ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1420_VERIFICA_MATRIZ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1420_VERIFICA_MATRIZ_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE406_IND_RET_SUBSCRICAO = result[i++].Value?.ToString();
            dta.VIND_RET_SUBSCRICAO = string.IsNullOrWhiteSpace(dta.GE406_IND_RET_SUBSCRICAO) ? "-1" : "0";
            dta.GE406_PCT_AGRAVO = result[i++].Value?.ToString();
            dta.VIND_PCT_AGRAVO = string.IsNullOrWhiteSpace(dta.GE406_PCT_AGRAVO) ? "-1" : "0";
            dta.GE406_VLR_PRM_SEM_AGR = result[i++].Value?.ToString();
            dta.VIND_VLR_PRM_SEM_AGR = string.IsNullOrWhiteSpace(dta.GE406_VLR_PRM_SEM_AGR) ? "-1" : "0";
            return dta;
        }

    }
}