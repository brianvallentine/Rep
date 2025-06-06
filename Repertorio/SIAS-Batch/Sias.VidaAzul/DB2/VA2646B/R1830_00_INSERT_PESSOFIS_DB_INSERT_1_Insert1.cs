using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class R1830_00_INSERT_PESSOFIS_DB_INSERT_1_Insert1 : QueryBasis<R1830_00_INSERT_PESSOFIS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PESSOA_FISICA
            ( COD_PESSOA ,
            CPF ,
            DATA_NASCIMENTO ,
            SEXO ,
            COD_USUARIO ,
            ESTADO_CIVIL ,
            TIMESTAMP ,
            NUM_IDENTIDADE ,
            ORGAO_EXPEDIDOR ,
            UF_EXPEDIDORA ,
            DATA_EXPEDICAO ,
            COD_CBO ,
            TIPO_IDENT_SIVPF
            )
            VALUES
            (
            :PESSOA-COD-PESSOA ,
            :PESSOFIS-CPF ,
            :CLIENTES-DATA-NASCIMENTO ,
            :PESSOFIS-SEXO ,
            :PESSOFIS-COD-USUARIO ,
            :CLIENTES-ESTADO-CIVIL ,
            CURRENT TIMESTAMP ,
            :PESSOFIS-NUM-IDENTIDADE :VIND-NULL,
            :PESSOFIS-ORGAO-EXPEDIDOR:VIND-NULL,
            :PESSOFIS-UF-EXPEDIDORA :VIND-NULL,
            :PESSOFIS-DATA-EXPEDICAO :VIND-NULL,
            :PESSOFIS-COD-CBO :VIND-NULL,
            :PESSOFIS-TIPO-IDENT-SIVPF :VIND-NULL
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA_FISICA ( COD_PESSOA , CPF , DATA_NASCIMENTO , SEXO , COD_USUARIO , ESTADO_CIVIL , TIMESTAMP , NUM_IDENTIDADE , ORGAO_EXPEDIDOR , UF_EXPEDIDORA , DATA_EXPEDICAO , COD_CBO , TIPO_IDENT_SIVPF ) VALUES ( {FieldThreatment(this.PESSOA_COD_PESSOA)} , {FieldThreatment(this.PESSOFIS_CPF)} , {FieldThreatment(this.CLIENTES_DATA_NASCIMENTO)} , {FieldThreatment(this.PESSOFIS_SEXO)} , {FieldThreatment(this.PESSOFIS_COD_USUARIO)} , {FieldThreatment(this.CLIENTES_ESTADO_CIVIL)} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_NULL?.ToInt() == -1 ? null : this.PESSOFIS_NUM_IDENTIDADE))},  {FieldThreatment((this.VIND_NULL?.ToInt() == -1 ? null : this.PESSOFIS_ORGAO_EXPEDIDOR))},  {FieldThreatment((this.VIND_NULL?.ToInt() == -1 ? null : this.PESSOFIS_UF_EXPEDIDORA))},  {FieldThreatment((this.VIND_NULL?.ToInt() == -1 ? null : this.PESSOFIS_DATA_EXPEDICAO))},  {FieldThreatment((this.VIND_NULL?.ToInt() == -1 ? null : this.PESSOFIS_COD_CBO))},  {FieldThreatment((this.VIND_NULL?.ToInt() == -1 ? null : this.PESSOFIS_TIPO_IDENT_SIVPF))} )";

            return query;
        }
        public string PESSOA_COD_PESSOA { get; set; }
        public string PESSOFIS_CPF { get; set; }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string PESSOFIS_SEXO { get; set; }
        public string PESSOFIS_COD_USUARIO { get; set; }
        public string CLIENTES_ESTADO_CIVIL { get; set; }
        public string PESSOFIS_NUM_IDENTIDADE { get; set; }
        public string VIND_NULL { get; set; }
        public string PESSOFIS_ORGAO_EXPEDIDOR { get; set; }
        public string PESSOFIS_UF_EXPEDIDORA { get; set; }
        public string PESSOFIS_DATA_EXPEDICAO { get; set; }
        public string PESSOFIS_COD_CBO { get; set; }
        public string PESSOFIS_TIPO_IDENT_SIVPF { get; set; }

        public static void Execute(R1830_00_INSERT_PESSOFIS_DB_INSERT_1_Insert1 r1830_00_INSERT_PESSOFIS_DB_INSERT_1_Insert1)
        {
            var ths = r1830_00_INSERT_PESSOFIS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1830_00_INSERT_PESSOFIS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}