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
    public class P0820_05_INICIO_DB_INSERT_1_Insert1 : QueryBasis<P0820_05_INICIO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_CRITICA_PROPOSTA
            ( NUM_CERTIFICADO
            ,SEQ_CRITICA
            ,IND_TP_PROPOSTA
            ,COD_MSG_CRITICA
            ,NUM_CPF_CNPJ
            ,NUM_PROPOSTA
            ,VLR_IS
            ,VLR_PREMIO
            ,DTA_OCORRENCIA
            ,DTA_RCAP
            ,STA_CRITICA
            ,DES_COMPLEMENTAR
            ,COD_USUARIO
            ,NOM_PROGRAMA
            ,DTH_CADASTRAMENTO )
            VALUES ( :VG103-NUM-CERTIFICADO
            ,:VG103-SEQ-CRITICA
            ,:VG103-IND-TP-PROPOSTA
            ,:VG103-COD-MSG-CRITICA
            ,:VG103-NUM-CPF-CNPJ
            ,:VG103-NUM-PROPOSTA
            :WH-VG103INUM-PROPOSTA
            ,:VG103-VLR-IS
            ,:VG103-VLR-PREMIO
            ,:VG103-DTA-OCORRENCIA
            ,:VG103-DTA-RCAP
            ,:VG103-STA-CRITICA
            ,:VG103-DES-COMPLEMENTAR
            :WH-VG103IDES-COMPLEMENTAR
            ,:VG103-COD-USUARIO
            ,:VG103-NOM-PROGRAMA
            ,:VG103-DTH-CADASTRAMENTO )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_CRITICA_PROPOSTA ( NUM_CERTIFICADO ,SEQ_CRITICA ,IND_TP_PROPOSTA ,COD_MSG_CRITICA ,NUM_CPF_CNPJ ,NUM_PROPOSTA ,VLR_IS ,VLR_PREMIO ,DTA_OCORRENCIA ,DTA_RCAP ,STA_CRITICA ,DES_COMPLEMENTAR ,COD_USUARIO ,NOM_PROGRAMA ,DTH_CADASTRAMENTO ) VALUES ( {FieldThreatment(this.VG103_NUM_CERTIFICADO)} ,{FieldThreatment(this.VG103_SEQ_CRITICA)} ,{FieldThreatment(this.VG103_IND_TP_PROPOSTA)} ,{FieldThreatment(this.VG103_COD_MSG_CRITICA)} ,{FieldThreatment(this.VG103_NUM_CPF_CNPJ)} , {FieldThreatment((this.WH_VG103INUM_PROPOSTA?.ToInt() == -1 ? null : this.VG103_NUM_PROPOSTA))} ,{FieldThreatment(this.VG103_VLR_IS)} ,{FieldThreatment(this.VG103_VLR_PREMIO)} ,{FieldThreatment(this.VG103_DTA_OCORRENCIA)} ,{FieldThreatment(this.VG103_DTA_RCAP)} ,{FieldThreatment(this.VG103_STA_CRITICA)} , {FieldThreatment((this.WH_VG103IDES_COMPLEMENTAR?.ToInt() == -1 ? null : this.VG103_DES_COMPLEMENTAR))} ,{FieldThreatment(this.VG103_COD_USUARIO)} ,{FieldThreatment(this.VG103_NOM_PROGRAMA)} ,{FieldThreatment(this.VG103_DTH_CADASTRAMENTO)} )";

            return query;
        }
        public string VG103_NUM_CERTIFICADO { get; set; }
        public string VG103_SEQ_CRITICA { get; set; }
        public string VG103_IND_TP_PROPOSTA { get; set; }
        public string VG103_COD_MSG_CRITICA { get; set; }
        public string VG103_NUM_CPF_CNPJ { get; set; }
        public string VG103_NUM_PROPOSTA { get; set; }
        public string WH_VG103INUM_PROPOSTA { get; set; }
        public string VG103_VLR_IS { get; set; }
        public string VG103_VLR_PREMIO { get; set; }
        public string VG103_DTA_OCORRENCIA { get; set; }
        public string VG103_DTA_RCAP { get; set; }
        public string VG103_STA_CRITICA { get; set; }
        public string VG103_DES_COMPLEMENTAR { get; set; }
        public string WH_VG103IDES_COMPLEMENTAR { get; set; }
        public string VG103_COD_USUARIO { get; set; }
        public string VG103_NOM_PROGRAMA { get; set; }
        public string VG103_DTH_CADASTRAMENTO { get; set; }

        public static void Execute(P0820_05_INICIO_DB_INSERT_1_Insert1 p0820_05_INICIO_DB_INSERT_1_Insert1)
        {
            var ths = p0820_05_INICIO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P0820_05_INICIO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}