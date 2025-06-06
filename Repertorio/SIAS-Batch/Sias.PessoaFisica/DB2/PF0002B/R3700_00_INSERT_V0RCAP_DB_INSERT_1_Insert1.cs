using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0002B
{
    public class R3700_00_INSERT_V0RCAP_DB_INSERT_1_Insert1 : QueryBasis<R3700_00_INSERT_V0RCAP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0RCAP
            VALUES (:V0RCAP-FONTE ,
            :V0RCAP-NRRCAP ,
            :V0RCAP-NRPROPOS ,
            :V0RCAP-NOME ,
            :V0RCAP-VLRCAP ,
            :V0RCAP-VALPRI ,
            :V0RCAP-DTCADAST ,
            :V0RCAP-DTMOVTO ,
            :V0RCAP-SITUACAO ,
            :V0RCAP-OPERACAO ,
            :V0RCAP-CODEMP:VIND-CODEMP ,
            CURRENT TIMESTAMP ,
            :V0RCAP-NUMAPOL:VIND-NUMAPOL ,
            :V0RCAP-NRENDOS:VIND-NRENDOS ,
            :V0RCAP-NRPARCEL:VIND-NRPARCEL ,
            :V0RCAP-NRTIT:VIND-NRTIT ,
            :V0RCAP-CODPRODU:VIND-CODPRODU ,
            :V0RCAP-AGECOBR:VIND-AGECOBR ,
            :V0RCAP-RECUPERA:VIND-RECUPERA ,
            :V0RCAP-ACRESCIMO:VIND-ACRESCIMO,
            :V0RCAP-NRCERTIF:VIND-NRCERTIF)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RCAP VALUES ({FieldThreatment(this.V0RCAP_FONTE)} , {FieldThreatment(this.V0RCAP_NRRCAP)} , {FieldThreatment(this.V0RCAP_NRPROPOS)} , {FieldThreatment(this.V0RCAP_NOME)} , {FieldThreatment(this.V0RCAP_VLRCAP)} , {FieldThreatment(this.V0RCAP_VALPRI)} , {FieldThreatment(this.V0RCAP_DTCADAST)} , {FieldThreatment(this.V0RCAP_DTMOVTO)} , {FieldThreatment(this.V0RCAP_SITUACAO)} , {FieldThreatment(this.V0RCAP_OPERACAO)} ,  {FieldThreatment((this.VIND_CODEMP?.ToInt() == -1 ? null : this.V0RCAP_CODEMP))} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_NUMAPOL?.ToInt() == -1 ? null : this.V0RCAP_NUMAPOL))} ,  {FieldThreatment((this.VIND_NRENDOS?.ToInt() == -1 ? null : this.V0RCAP_NRENDOS))} ,  {FieldThreatment((this.VIND_NRPARCEL?.ToInt() == -1 ? null : this.V0RCAP_NRPARCEL))} ,  {FieldThreatment((this.VIND_NRTIT?.ToInt() == -1 ? null : this.V0RCAP_NRTIT))} ,  {FieldThreatment((this.VIND_CODPRODU?.ToInt() == -1 ? null : this.V0RCAP_CODPRODU))} ,  {FieldThreatment((this.VIND_AGECOBR?.ToInt() == -1 ? null : this.V0RCAP_AGECOBR))} ,  {FieldThreatment((this.VIND_RECUPERA?.ToInt() == -1 ? null : this.V0RCAP_RECUPERA))} ,  {FieldThreatment((this.VIND_ACRESCIMO?.ToInt() == -1 ? null : this.V0RCAP_ACRESCIMO))},  {FieldThreatment((this.VIND_NRCERTIF?.ToInt() == -1 ? null : this.V0RCAP_NRCERTIF))})";

            return query;
        }
        public string V0RCAP_FONTE { get; set; }
        public string V0RCAP_NRRCAP { get; set; }
        public string V0RCAP_NRPROPOS { get; set; }
        public string V0RCAP_NOME { get; set; }
        public string V0RCAP_VLRCAP { get; set; }
        public string V0RCAP_VALPRI { get; set; }
        public string V0RCAP_DTCADAST { get; set; }
        public string V0RCAP_DTMOVTO { get; set; }
        public string V0RCAP_SITUACAO { get; set; }
        public string V0RCAP_OPERACAO { get; set; }
        public string V0RCAP_CODEMP { get; set; }
        public string VIND_CODEMP { get; set; }
        public string V0RCAP_NUMAPOL { get; set; }
        public string VIND_NUMAPOL { get; set; }
        public string V0RCAP_NRENDOS { get; set; }
        public string VIND_NRENDOS { get; set; }
        public string V0RCAP_NRPARCEL { get; set; }
        public string VIND_NRPARCEL { get; set; }
        public string V0RCAP_NRTIT { get; set; }
        public string VIND_NRTIT { get; set; }
        public string V0RCAP_CODPRODU { get; set; }
        public string VIND_CODPRODU { get; set; }
        public string V0RCAP_AGECOBR { get; set; }
        public string VIND_AGECOBR { get; set; }
        public string V0RCAP_RECUPERA { get; set; }
        public string VIND_RECUPERA { get; set; }
        public string V0RCAP_ACRESCIMO { get; set; }
        public string VIND_ACRESCIMO { get; set; }
        public string V0RCAP_NRCERTIF { get; set; }
        public string VIND_NRCERTIF { get; set; }

        public static void Execute(R3700_00_INSERT_V0RCAP_DB_INSERT_1_Insert1 r3700_00_INSERT_V0RCAP_DB_INSERT_1_Insert1)
        {
            var ths = r3700_00_INSERT_V0RCAP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3700_00_INSERT_V0RCAP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}