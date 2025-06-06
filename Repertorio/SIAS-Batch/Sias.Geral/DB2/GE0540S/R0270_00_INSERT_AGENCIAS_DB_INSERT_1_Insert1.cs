using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0540S
{
    public class R0270_00_INSERT_AGENCIAS_DB_INSERT_1_Insert1 : QueryBasis<R0270_00_INSERT_AGENCIAS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.AGENCIAS
            (COD_BANCO ,
            COD_AGENCIA ,
            DAC_AGENCIA ,
            NOME_AGENCIA ,
            CIDADE ,
            SIGLA_UF ,
            ENDERECO ,
            TELEFONE ,
            DDD ,
            FAX ,
            TELEX ,
            CEP ,
            TIPO_CONTA ,
            NUM_CTA_CORRENTE ,
            DAC_CTA_CORRENTE ,
            SIT_REGISTRO ,
            COD_EMPRESA )
            VALUES
            (:AGENCIAS-COD-BANCO ,
            :AGENCIAS-COD-AGENCIA ,
            :AGENCIAS-DAC-AGENCIA ,
            :AGENCIAS-NOME-AGENCIA ,
            :AGENCIAS-CIDADE ,
            :AGENCIAS-SIGLA-UF ,
            :AGENCIAS-ENDERECO ,
            :AGENCIAS-TELEFONE ,
            :AGENCIAS-DDD ,
            :AGENCIAS-FAX ,
            :AGENCIAS-TELEX ,
            :AGENCIAS-CEP ,
            :AGENCIAS-TIPO-CONTA ,
            :AGENCIAS-NUM-CTA-CORRENTE ,
            :AGENCIAS-DAC-CTA-CORRENTE ,
            :AGENCIAS-SIT-REGISTRO ,
            :AGENCIAS-COD-EMPRESA:VIND-NULL01)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.AGENCIAS (COD_BANCO , COD_AGENCIA , DAC_AGENCIA , NOME_AGENCIA , CIDADE , SIGLA_UF , ENDERECO , TELEFONE , DDD , FAX , TELEX , CEP , TIPO_CONTA , NUM_CTA_CORRENTE , DAC_CTA_CORRENTE , SIT_REGISTRO , COD_EMPRESA ) VALUES ({FieldThreatment(this.AGENCIAS_COD_BANCO)} , {FieldThreatment(this.AGENCIAS_COD_AGENCIA)} , {FieldThreatment(this.AGENCIAS_DAC_AGENCIA)} , {FieldThreatment(this.AGENCIAS_NOME_AGENCIA)} , {FieldThreatment(this.AGENCIAS_CIDADE)} , {FieldThreatment(this.AGENCIAS_SIGLA_UF)} , {FieldThreatment(this.AGENCIAS_ENDERECO)} , {FieldThreatment(this.AGENCIAS_TELEFONE)} , {FieldThreatment(this.AGENCIAS_DDD)} , {FieldThreatment(this.AGENCIAS_FAX)} , {FieldThreatment(this.AGENCIAS_TELEX)} , {FieldThreatment(this.AGENCIAS_CEP)} , {FieldThreatment(this.AGENCIAS_TIPO_CONTA)} , {FieldThreatment(this.AGENCIAS_NUM_CTA_CORRENTE)} , {FieldThreatment(this.AGENCIAS_DAC_CTA_CORRENTE)} , {FieldThreatment(this.AGENCIAS_SIT_REGISTRO)} ,  {FieldThreatment((this.VIND_NULL01?.ToInt() == -1 ? null : this.AGENCIAS_COD_EMPRESA))})";

            return query;
        }
        public string AGENCIAS_COD_BANCO { get; set; }
        public string AGENCIAS_COD_AGENCIA { get; set; }
        public string AGENCIAS_DAC_AGENCIA { get; set; }
        public string AGENCIAS_NOME_AGENCIA { get; set; }
        public string AGENCIAS_CIDADE { get; set; }
        public string AGENCIAS_SIGLA_UF { get; set; }
        public string AGENCIAS_ENDERECO { get; set; }
        public string AGENCIAS_TELEFONE { get; set; }
        public string AGENCIAS_DDD { get; set; }
        public string AGENCIAS_FAX { get; set; }
        public string AGENCIAS_TELEX { get; set; }
        public string AGENCIAS_CEP { get; set; }
        public string AGENCIAS_TIPO_CONTA { get; set; }
        public string AGENCIAS_NUM_CTA_CORRENTE { get; set; }
        public string AGENCIAS_DAC_CTA_CORRENTE { get; set; }
        public string AGENCIAS_SIT_REGISTRO { get; set; }
        public string AGENCIAS_COD_EMPRESA { get; set; }
        public string VIND_NULL01 { get; set; }

        public static void Execute(R0270_00_INSERT_AGENCIAS_DB_INSERT_1_Insert1 r0270_00_INSERT_AGENCIAS_DB_INSERT_1_Insert1)
        {
            var ths = r0270_00_INSERT_AGENCIAS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0270_00_INSERT_AGENCIAS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}