using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0099B
{
    public class R2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1_Insert1 : QueryBasis<R2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_ACOPLADO_PRESTAMISTA
            ( NUM_CERTIFICADO
            ,COD_PRODUTO
            ,COD_ACOPLADO
            ,NUM_ARQ_PROPOSTA
            ,DES_ACOPLADO
            ,DTA_INI_VIGENCIA
            ,DTA_FIM_VIGENCIA
            ,STA_REGISTRO
            ,NOM_PROGRAMA
            ,DTH_ATUALIZACAO)
            VALUES
            ( :VG097-NUM-CERTIFICADO
            ,:VG097-COD-PRODUTO
            ,:VG097-COD-ACOPLADO
            ,:VG097-NUM-ARQ-PROPOSTA
            ,:VG097-DES-ACOPLADO
            ,:VG097-DTA-INI-VIGENCIA
            ,:VG097-DTA-FIM-VIGENCIA
            ,:VG097-STA-REGISTRO
            ,:VG097-NOM-PROGRAMA
            , CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_ACOPLADO_PRESTAMISTA ( NUM_CERTIFICADO ,COD_PRODUTO ,COD_ACOPLADO ,NUM_ARQ_PROPOSTA ,DES_ACOPLADO ,DTA_INI_VIGENCIA ,DTA_FIM_VIGENCIA ,STA_REGISTRO ,NOM_PROGRAMA ,DTH_ATUALIZACAO) VALUES ( {FieldThreatment(this.VG097_NUM_CERTIFICADO)} ,{FieldThreatment(this.VG097_COD_PRODUTO)} ,{FieldThreatment(this.VG097_COD_ACOPLADO)} ,{FieldThreatment(this.VG097_NUM_ARQ_PROPOSTA)} ,{FieldThreatment(this.VG097_DES_ACOPLADO)} ,{FieldThreatment(this.VG097_DTA_INI_VIGENCIA)} ,{FieldThreatment(this.VG097_DTA_FIM_VIGENCIA)} ,{FieldThreatment(this.VG097_STA_REGISTRO)} ,{FieldThreatment(this.VG097_NOM_PROGRAMA)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string VG097_NUM_CERTIFICADO { get; set; }
        public string VG097_COD_PRODUTO { get; set; }
        public string VG097_COD_ACOPLADO { get; set; }
        public string VG097_NUM_ARQ_PROPOSTA { get; set; }
        public string VG097_DES_ACOPLADO { get; set; }
        public string VG097_DTA_INI_VIGENCIA { get; set; }
        public string VG097_DTA_FIM_VIGENCIA { get; set; }
        public string VG097_STA_REGISTRO { get; set; }
        public string VG097_NOM_PROGRAMA { get; set; }

        public static void Execute(R2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1_Insert1 r2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1_Insert1)
        {
            var ths = r2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}