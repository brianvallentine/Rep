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
    public class P0821_05_INICIO_DB_INSERT_1_Insert1 : QueryBasis<P0821_05_INICIO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_DPS_PROPOSTA_HIST
            ( NUM_PROPOSTA
            ,NUM_CPF_CNPJ
            ,DTH_CADASTRAMENTO
            ,SEQ_PRODUTO_DPS
            ,STA_DPS_PROPOSTA
            ,IND_TP_PESSOA
            ,IND_TP_SEGURADO
            ,NUM_CERTIFICADO
            ,VLR_IS
            ,VLR_ACUMULO_IS
            ,COD_USUARIO
            ,NOM_PROGRAMA )
            VALUES ( :VG143-NUM-PROPOSTA
            ,:VG143-NUM-CPF-CNPJ
            ,:VG143-DTH-CADASTRAMENTO
            ,:VG143-SEQ-PRODUTO-DPS
            ,:VG143-STA-DPS-PROPOSTA
            ,:VG143-IND-TP-PESSOA
            ,:VG143-IND-TP-SEGURADO
            ,:VG143-NUM-CERTIFICADO
            ,:VG143-VLR-IS
            ,:VG143-VLR-ACUMULO-IS
            ,:VG143-COD-USUARIO
            ,:VG143-NOM-PROGRAMA )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_DPS_PROPOSTA_HIST ( NUM_PROPOSTA ,NUM_CPF_CNPJ ,DTH_CADASTRAMENTO ,SEQ_PRODUTO_DPS ,STA_DPS_PROPOSTA ,IND_TP_PESSOA ,IND_TP_SEGURADO ,NUM_CERTIFICADO ,VLR_IS ,VLR_ACUMULO_IS ,COD_USUARIO ,NOM_PROGRAMA ) VALUES ( {FieldThreatment(this.VG143_NUM_PROPOSTA)} ,{FieldThreatment(this.VG143_NUM_CPF_CNPJ)} ,{FieldThreatment(this.VG143_DTH_CADASTRAMENTO)} ,{FieldThreatment(this.VG143_SEQ_PRODUTO_DPS)} ,{FieldThreatment(this.VG143_STA_DPS_PROPOSTA)} ,{FieldThreatment(this.VG143_IND_TP_PESSOA)} ,{FieldThreatment(this.VG143_IND_TP_SEGURADO)} ,{FieldThreatment(this.VG143_NUM_CERTIFICADO)} ,{FieldThreatment(this.VG143_VLR_IS)} ,{FieldThreatment(this.VG143_VLR_ACUMULO_IS)} ,{FieldThreatment(this.VG143_COD_USUARIO)} ,{FieldThreatment(this.VG143_NOM_PROGRAMA)} )";

            return query;
        }
        public string VG143_NUM_PROPOSTA { get; set; }
        public string VG143_NUM_CPF_CNPJ { get; set; }
        public string VG143_DTH_CADASTRAMENTO { get; set; }
        public string VG143_SEQ_PRODUTO_DPS { get; set; }
        public string VG143_STA_DPS_PROPOSTA { get; set; }
        public string VG143_IND_TP_PESSOA { get; set; }
        public string VG143_IND_TP_SEGURADO { get; set; }
        public string VG143_NUM_CERTIFICADO { get; set; }
        public string VG143_VLR_IS { get; set; }
        public string VG143_VLR_ACUMULO_IS { get; set; }
        public string VG143_COD_USUARIO { get; set; }
        public string VG143_NOM_PROGRAMA { get; set; }

        public static void Execute(P0821_05_INICIO_DB_INSERT_1_Insert1 p0821_05_INICIO_DB_INSERT_1_Insert1)
        {
            var ths = p0821_05_INICIO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P0821_05_INICIO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}