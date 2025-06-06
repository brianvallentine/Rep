using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG017
{
    public class P0130_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0130_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VG143.NUM_PROPOSTA
            ,VG143.NUM_CPF_CNPJ
            ,VG143.SEQ_PRODUTO_DPS
            ,VG143.STA_DPS_PROPOSTA
            ,VG143.IND_TP_PESSOA
            ,VG143.IND_TP_SEGURADO
            ,VALUE(VG143.NUM_CERTIFICADO,0)
            ,VALUE(VG143.VLR_IS,0)
            ,VALUE(VG143.VLR_ACUMULO_IS,0)
            ,VG143.COD_USUARIO
            ,VG143.NOM_PROGRAMA
            ,VG143.DTH_CADASTRAMENTO
            INTO :VG143-NUM-PROPOSTA
            ,:VG143-NUM-CPF-CNPJ
            ,:VG143-SEQ-PRODUTO-DPS
            ,:VG143-STA-DPS-PROPOSTA
            ,:VG143-IND-TP-PESSOA
            ,:VG143-IND-TP-SEGURADO
            ,:VG143-NUM-CERTIFICADO
            ,:VG143-VLR-IS
            ,:VG143-VLR-ACUMULO-IS
            ,:VG143-COD-USUARIO
            ,:VG143-NOM-PROGRAMA
            ,:VG143-DTH-CADASTRAMENTO
            FROM SEGUROS.VG_DPS_PROPOSTA VG143
            WHERE VG143.NUM_PROPOSTA = :VG143-NUM-PROPOSTA
            OR VALUE(VG143.NUM_CERTIFICADO, 1)
            = :VG143-NUM-CERTIFICADO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VG143.NUM_PROPOSTA
											,VG143.NUM_CPF_CNPJ
											,VG143.SEQ_PRODUTO_DPS
											,VG143.STA_DPS_PROPOSTA
											,VG143.IND_TP_PESSOA
											,VG143.IND_TP_SEGURADO
											,VALUE(VG143.NUM_CERTIFICADO
							,0)
											,VALUE(VG143.VLR_IS
							,0)
											,VALUE(VG143.VLR_ACUMULO_IS
							,0)
											,VG143.COD_USUARIO
											,VG143.NOM_PROGRAMA
											,VG143.DTH_CADASTRAMENTO
											FROM SEGUROS.VG_DPS_PROPOSTA VG143
											WHERE VG143.NUM_PROPOSTA = '{this.VG143_NUM_PROPOSTA}'
											OR VALUE(VG143.NUM_CERTIFICADO
							, 1)
											= '{this.VG143_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string VG143_NUM_PROPOSTA { get; set; }
        public string VG143_NUM_CPF_CNPJ { get; set; }
        public string VG143_SEQ_PRODUTO_DPS { get; set; }
        public string VG143_STA_DPS_PROPOSTA { get; set; }
        public string VG143_IND_TP_PESSOA { get; set; }
        public string VG143_IND_TP_SEGURADO { get; set; }
        public string VG143_NUM_CERTIFICADO { get; set; }
        public string VG143_VLR_IS { get; set; }
        public string VG143_VLR_ACUMULO_IS { get; set; }
        public string VG143_COD_USUARIO { get; set; }
        public string VG143_NOM_PROGRAMA { get; set; }
        public string VG143_DTH_CADASTRAMENTO { get; set; }

        public static P0130_05_INICIO_DB_SELECT_1_Query1 Execute(P0130_05_INICIO_DB_SELECT_1_Query1 p0130_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0130_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0130_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0130_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG143_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.VG143_NUM_CPF_CNPJ = result[i++].Value?.ToString();
            dta.VG143_SEQ_PRODUTO_DPS = result[i++].Value?.ToString();
            dta.VG143_STA_DPS_PROPOSTA = result[i++].Value?.ToString();
            dta.VG143_IND_TP_PESSOA = result[i++].Value?.ToString();
            dta.VG143_IND_TP_SEGURADO = result[i++].Value?.ToString();
            dta.VG143_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.VG143_VLR_IS = result[i++].Value?.ToString();
            dta.VG143_VLR_ACUMULO_IS = result[i++].Value?.ToString();
            dta.VG143_COD_USUARIO = result[i++].Value?.ToString();
            dta.VG143_NOM_PROGRAMA = result[i++].Value?.ToString();
            dta.VG143_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}