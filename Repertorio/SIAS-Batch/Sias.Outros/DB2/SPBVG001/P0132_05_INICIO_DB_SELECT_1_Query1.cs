using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG001
{
    public class P0132_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0132_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VG103.NUM_CERTIFICADO
            ,VG103.SEQ_CRITICA
            ,VG103.IND_TP_PROPOSTA
            ,VG103.COD_MSG_CRITICA
            ,VG102.DES_MSG_CRITICA
            ,VG102.DES_ABREV_MSG_CRITICA
            ,VG103.NUM_CPF_CNPJ
            ,VALUE(VG103.NUM_PROPOSTA,0)
            ,VG103.VLR_IS
            ,VG103.VLR_PREMIO
            ,VG103.DTA_OCORRENCIA
            ,VG103.DTA_RCAP
            ,VG103.STA_CRITICA
            ,VG099.DES_STA_CRITICA
            ,VALUE(VG103.DES_COMPLEMENTAR, ' ' )
            ,VG103.COD_USUARIO
            ,VG103.NOM_PROGRAMA
            ,CHAR(VG103.DTH_CADASTRAMENTO)
            INTO :VG103-NUM-CERTIFICADO
            ,:VG103-SEQ-CRITICA
            ,:VG103-IND-TP-PROPOSTA
            ,:VG103-COD-MSG-CRITICA
            ,:VG102-DES-MSG-CRITICA
            ,:VG102-DES-ABREV-MSG-CRITICA
            ,:VG103-NUM-CPF-CNPJ
            ,:VG103-NUM-PROPOSTA
            ,:VG103-VLR-IS
            ,:VG103-VLR-PREMIO
            ,:VG103-DTA-OCORRENCIA
            ,:VG103-DTA-RCAP
            ,:VG103-STA-CRITICA
            ,:VG099-DES-STA-CRITICA
            ,:VG103-DES-COMPLEMENTAR
            ,:VG103-COD-USUARIO
            ,:VG103-NOM-PROGRAMA
            ,:VG103-DTH-CADASTRAMENTO
            FROM SEGUROS.VG_CRITICA_PROPOSTA VG103
            ,SEGUROS.VG_DM_STA_CRITICA VG099
            ,SEGUROS.VG_DM_MSG_CRITICA VG102
            WHERE VG103.NUM_CERTIFICADO = :VG103-NUM-CERTIFICADO
            AND VG103.COD_MSG_CRITICA = :VG103-COD-MSG-CRITICA
            AND VG099.STA_CRITICA = VG103.STA_CRITICA
            AND VG102.COD_MSG_CRITICA = VG103.COD_MSG_CRITICA
            AND VG103.DTH_CADASTRAMENTO
            = ( SELECT MAX(VG103V.DTH_CADASTRAMENTO)
            FROM SEGUROS.VG_CRITICA_PROPOSTA VG103V
            WHERE VG103V.NUM_CERTIFICADO =
            VG103.NUM_CERTIFICADO
            AND VG103V.COD_MSG_CRITICA =
            VG103.COD_MSG_CRITICA
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VG103.NUM_CERTIFICADO
											,VG103.SEQ_CRITICA
											,VG103.IND_TP_PROPOSTA
											,VG103.COD_MSG_CRITICA
											,VG102.DES_MSG_CRITICA
											,VG102.DES_ABREV_MSG_CRITICA
											,VG103.NUM_CPF_CNPJ
											,VALUE(VG103.NUM_PROPOSTA
							,0)
											,VG103.VLR_IS
											,VG103.VLR_PREMIO
											,VG103.DTA_OCORRENCIA
											,VG103.DTA_RCAP
											,VG103.STA_CRITICA
											,VG099.DES_STA_CRITICA
											,VALUE(VG103.DES_COMPLEMENTAR
							, ' ' )
											,VG103.COD_USUARIO
											,VG103.NOM_PROGRAMA
											,CHAR(VG103.DTH_CADASTRAMENTO)
											FROM SEGUROS.VG_CRITICA_PROPOSTA VG103
											,SEGUROS.VG_DM_STA_CRITICA VG099
											,SEGUROS.VG_DM_MSG_CRITICA VG102
											WHERE VG103.NUM_CERTIFICADO = '{this.VG103_NUM_CERTIFICADO}'
											AND VG103.COD_MSG_CRITICA = '{this.VG103_COD_MSG_CRITICA}'
											AND VG099.STA_CRITICA = VG103.STA_CRITICA
											AND VG102.COD_MSG_CRITICA = VG103.COD_MSG_CRITICA
											AND VG103.DTH_CADASTRAMENTO
											= ( SELECT MAX(VG103V.DTH_CADASTRAMENTO)
											FROM SEGUROS.VG_CRITICA_PROPOSTA VG103V
											WHERE VG103V.NUM_CERTIFICADO =
											VG103.NUM_CERTIFICADO
											AND VG103V.COD_MSG_CRITICA =
											VG103.COD_MSG_CRITICA
											)";

            return query;
        }
        public string VG103_NUM_CERTIFICADO { get; set; }
        public string VG103_SEQ_CRITICA { get; set; }
        public string VG103_IND_TP_PROPOSTA { get; set; }
        public string VG103_COD_MSG_CRITICA { get; set; }
        public string VG102_DES_MSG_CRITICA { get; set; }
        public string VG102_DES_ABREV_MSG_CRITICA { get; set; }
        public string VG103_NUM_CPF_CNPJ { get; set; }
        public string VG103_NUM_PROPOSTA { get; set; }
        public string VG103_VLR_IS { get; set; }
        public string VG103_VLR_PREMIO { get; set; }
        public string VG103_DTA_OCORRENCIA { get; set; }
        public string VG103_DTA_RCAP { get; set; }
        public string VG103_STA_CRITICA { get; set; }
        public string VG099_DES_STA_CRITICA { get; set; }
        public string VG103_DES_COMPLEMENTAR { get; set; }
        public string VG103_COD_USUARIO { get; set; }
        public string VG103_NOM_PROGRAMA { get; set; }
        public string VG103_DTH_CADASTRAMENTO { get; set; }

        public static P0132_05_INICIO_DB_SELECT_1_Query1 Execute(P0132_05_INICIO_DB_SELECT_1_Query1 p0132_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0132_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0132_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0132_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG103_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.VG103_SEQ_CRITICA = result[i++].Value?.ToString();
            dta.VG103_IND_TP_PROPOSTA = result[i++].Value?.ToString();
            dta.VG103_COD_MSG_CRITICA = result[i++].Value?.ToString();
            dta.VG102_DES_MSG_CRITICA = result[i++].Value?.ToString();
            dta.VG102_DES_ABREV_MSG_CRITICA = result[i++].Value?.ToString();
            dta.VG103_NUM_CPF_CNPJ = result[i++].Value?.ToString();
            dta.VG103_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.VG103_VLR_IS = result[i++].Value?.ToString();
            dta.VG103_VLR_PREMIO = result[i++].Value?.ToString();
            dta.VG103_DTA_OCORRENCIA = result[i++].Value?.ToString();
            dta.VG103_DTA_RCAP = result[i++].Value?.ToString();
            dta.VG103_STA_CRITICA = result[i++].Value?.ToString();
            dta.VG099_DES_STA_CRITICA = result[i++].Value?.ToString();
            dta.VG103_DES_COMPLEMENTAR = result[i++].Value?.ToString();
            dta.VG103_COD_USUARIO = result[i++].Value?.ToString();
            dta.VG103_NOM_PROGRAMA = result[i++].Value?.ToString();
            dta.VG103_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}