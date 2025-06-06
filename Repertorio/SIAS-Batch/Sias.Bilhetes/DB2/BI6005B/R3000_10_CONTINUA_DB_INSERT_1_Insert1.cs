using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6005B
{
    public class R3000_10_CONTINUA_DB_INSERT_1_Insert1 : QueryBasis<R3000_10_CONTINUA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0PRODUTOR
            VALUES (:V1MCEF-COD-FONTE ,
            :V1FUNC-COD-ANGAR ,
            '3' ,
            :V1FUNC-NOME-FUN ,
            :V1FUNC-NUM-MATRIC ,
            0 ,
            ' ' ,
            :V1PROD-ENDERECO ,
            ' ' ,
            :V1PROD-CIDADE ,
            :V1FUNC-SIGLA-UF ,
            :V1FUNC-CEP ,
            0 ,
            0 ,
            0 ,
            ' ' ,
            ' ' ,
            0 ,
            :V1FUNC-NUM-CPF ,
            0 ,
            0 ,
            'F' ,
            'S' ,
            :V1SURG-PCDESISS ,
            ' ' ,
            ' ' ,
            104 ,
            :V0BILH-AGENCIA ,
            0 ,
            '0' ,
            0 ,
            0 ,
            0 ,
            0 ,
            :V1SIST-DTMOVACB ,
            :V1SIST-DTMOVACB ,
            :V1SIST-DTMOVACB ,
            :WHOST-NUMREC ,
            0 ,
            '0' ,
            NULL ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0PRODUTOR VALUES ({FieldThreatment(this.V1MCEF_COD_FONTE)} , {FieldThreatment(this.V1FUNC_COD_ANGAR)} , '3' , {FieldThreatment(this.V1FUNC_NOME_FUN)} , {FieldThreatment(this.V1FUNC_NUM_MATRIC)} , 0 , ' ' , {FieldThreatment(this.V1PROD_ENDERECO)} , ' ' , {FieldThreatment(this.V1PROD_CIDADE)} , {FieldThreatment(this.V1FUNC_SIGLA_UF)} , {FieldThreatment(this.V1FUNC_CEP)} , 0 , 0 , 0 , ' ' , ' ' , 0 , {FieldThreatment(this.V1FUNC_NUM_CPF)} , 0 , 0 , 'F' , 'S' , {FieldThreatment(this.V1SURG_PCDESISS)} , ' ' , ' ' , 104 , {FieldThreatment(this.V0BILH_AGENCIA)} , 0 , '0' , 0 , 0 , 0 , 0 , {FieldThreatment(this.V1SIST_DTMOVACB)} , {FieldThreatment(this.V1SIST_DTMOVACB)} , {FieldThreatment(this.V1SIST_DTMOVACB)} , {FieldThreatment(this.WHOST_NUMREC)} , 0 , '0' , NULL , CURRENT TIMESTAMP)";

            return query;
        }
        public string V1MCEF_COD_FONTE { get; set; }
        public string V1FUNC_COD_ANGAR { get; set; }
        public string V1FUNC_NOME_FUN { get; set; }
        public string V1FUNC_NUM_MATRIC { get; set; }
        public string V1PROD_ENDERECO { get; set; }
        public string V1PROD_CIDADE { get; set; }
        public string V1FUNC_SIGLA_UF { get; set; }
        public string V1FUNC_CEP { get; set; }
        public string V1FUNC_NUM_CPF { get; set; }
        public string V1SURG_PCDESISS { get; set; }
        public string V0BILH_AGENCIA { get; set; }
        public string V1SIST_DTMOVACB { get; set; }
        public string WHOST_NUMREC { get; set; }

        public static void Execute(R3000_10_CONTINUA_DB_INSERT_1_Insert1 r3000_10_CONTINUA_DB_INSERT_1_Insert1)
        {
            var ths = r3000_10_CONTINUA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3000_10_CONTINUA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}