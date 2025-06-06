using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6252B
{
    public class R1160_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1 : QueryBasis<R1160_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PESSOA_FISICA VALUES
            (:PESSOFIS-COD-PESSOA ,
            :PESSOFIS-CPF ,
            :PESSOFIS-DATA-NASCIMENTO ,
            :PESSOFIS-SEXO ,
            :PESSOFIS-COD-USUARIO ,
            :PESSOFIS-ESTADO-CIVIL ,
            CURRENT TIMESTAMP ,
            :PESSOFIS-NUM-IDENTIDADE:VIND-NUM-IDENT ,
            :PESSOFIS-ORGAO-EXPEDIDOR:VIND-ORGAO-EXP ,
            :PESSOFIS-UF-EXPEDIDORA:VIND-UF-EXP ,
            :PESSOFIS-DATA-EXPEDICAO:VIND-DTEXPEDI ,
            :PESSOFIS-COD-CBO:VIND-COD-CBO ,
            :PESSOFIS-TIPO-IDENT-SIVPF:VIND-TP-IDENT)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA_FISICA VALUES ({FieldThreatment(this.PESSOFIS_COD_PESSOA)} , {FieldThreatment(this.PESSOFIS_CPF)} , {FieldThreatment(this.PESSOFIS_DATA_NASCIMENTO)} , {FieldThreatment(this.PESSOFIS_SEXO)} , {FieldThreatment(this.PESSOFIS_COD_USUARIO)} , {FieldThreatment(this.PESSOFIS_ESTADO_CIVIL)} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_NUM_IDENT?.ToInt() == -1 ? null : this.PESSOFIS_NUM_IDENTIDADE))} ,  {FieldThreatment((this.VIND_ORGAO_EXP?.ToInt() == -1 ? null : this.PESSOFIS_ORGAO_EXPEDIDOR))} ,  {FieldThreatment((this.VIND_UF_EXP?.ToInt() == -1 ? null : this.PESSOFIS_UF_EXPEDIDORA))} ,  {FieldThreatment((this.VIND_DTEXPEDI?.ToInt() == -1 ? null : this.PESSOFIS_DATA_EXPEDICAO))} ,  {FieldThreatment((this.VIND_COD_CBO?.ToInt() == -1 ? null : this.PESSOFIS_COD_CBO))} ,  {FieldThreatment((this.VIND_TP_IDENT?.ToInt() == -1 ? null : this.PESSOFIS_TIPO_IDENT_SIVPF))})";

            return query;
        }
        public string PESSOFIS_COD_PESSOA { get; set; }
        public string PESSOFIS_CPF { get; set; }
        public string PESSOFIS_DATA_NASCIMENTO { get; set; }
        public string PESSOFIS_SEXO { get; set; }
        public string PESSOFIS_COD_USUARIO { get; set; }
        public string PESSOFIS_ESTADO_CIVIL { get; set; }
        public string PESSOFIS_NUM_IDENTIDADE { get; set; }
        public string VIND_NUM_IDENT { get; set; }
        public string PESSOFIS_ORGAO_EXPEDIDOR { get; set; }
        public string VIND_ORGAO_EXP { get; set; }
        public string PESSOFIS_UF_EXPEDIDORA { get; set; }
        public string VIND_UF_EXP { get; set; }
        public string PESSOFIS_DATA_EXPEDICAO { get; set; }
        public string VIND_DTEXPEDI { get; set; }
        public string PESSOFIS_COD_CBO { get; set; }
        public string VIND_COD_CBO { get; set; }
        public string PESSOFIS_TIPO_IDENT_SIVPF { get; set; }
        public string VIND_TP_IDENT { get; set; }

        public static void Execute(R1160_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1 r1160_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1)
        {
            var ths = r1160_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1160_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}