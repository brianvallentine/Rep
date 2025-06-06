using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1 : QueryBasis<R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0COMISSAO_FENAE
            VALUES (:V0CFEN-CODEMP ,
            :V0CFEN-NUMBIL ,
            :V0CFEN-AGECOBR ,
            :V0CFEN-VALADT ,
            :V0CFEN-DTCREDITO ,
            :V0CFEN-MATRICULA ,
            :V0CFEN-AGECONTA ,
            :V0CFEN-OPECONTA ,
            :V0CFEN-NUMCONTA ,
            :V0CFEN-DIGCONTA ,
            :V0CFEN-AGECTADEB ,
            :V0CFEN-OPRCTADEB ,
            :V0CFEN-NUMCTADEB ,
            :V0CFEN-DIGCTADEB ,
            :V0CFEN-SINDICO ,
            :V0CFEN-DTQITBCO ,
            :V0CFEN-VLRCAP ,
            :V0CFEN-DTMOVTO ,
            :V0CFEN-SITUACAO ,
            CURRENT TIMESTAMP ,
            :V0CFEN-NRMATRGER:VIND-NRMATRGER ,
            :V0CFEN-VALADTGER:VIND-VALADTGER ,
            :V0CFEN-DTPAGGER:VIND-DTPAGGER ,
            :V0CFEN-DTCANCEL:VIND-DTCANCEL ,
            :V0CFEN-NRMATRSUN:VIND-NRMATRSUN ,
            :V0CFEN-VALADTSUN:VIND-VALADTSUN ,
            :V0CFEN-DTPAGSUN:VIND-DTPAGSUN)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COMISSAO_FENAE VALUES ({FieldThreatment(this.V0CFEN_CODEMP)} , {FieldThreatment(this.V0CFEN_NUMBIL)} , {FieldThreatment(this.V0CFEN_AGECOBR)} , {FieldThreatment(this.V0CFEN_VALADT)} , {FieldThreatment(this.V0CFEN_DTCREDITO)} , {FieldThreatment(this.V0CFEN_MATRICULA)} , {FieldThreatment(this.V0CFEN_AGECONTA)} , {FieldThreatment(this.V0CFEN_OPECONTA)} , {FieldThreatment(this.V0CFEN_NUMCONTA)} , {FieldThreatment(this.V0CFEN_DIGCONTA)} , {FieldThreatment(this.V0CFEN_AGECTADEB)} , {FieldThreatment(this.V0CFEN_OPRCTADEB)} , {FieldThreatment(this.V0CFEN_NUMCTADEB)} , {FieldThreatment(this.V0CFEN_DIGCTADEB)} , {FieldThreatment(this.V0CFEN_SINDICO)} , {FieldThreatment(this.V0CFEN_DTQITBCO)} , {FieldThreatment(this.V0CFEN_VLRCAP)} , {FieldThreatment(this.V0CFEN_DTMOVTO)} , {FieldThreatment(this.V0CFEN_SITUACAO)} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_NRMATRGER?.ToInt() == -1 ? null : this.V0CFEN_NRMATRGER))} ,  {FieldThreatment((this.VIND_VALADTGER?.ToInt() == -1 ? null : this.V0CFEN_VALADTGER))} ,  {FieldThreatment((this.VIND_DTPAGGER?.ToInt() == -1 ? null : this.V0CFEN_DTPAGGER))} ,  {FieldThreatment((this.VIND_DTCANCEL?.ToInt() == -1 ? null : this.V0CFEN_DTCANCEL))} ,  {FieldThreatment((this.VIND_NRMATRSUN?.ToInt() == -1 ? null : this.V0CFEN_NRMATRSUN))} ,  {FieldThreatment((this.VIND_VALADTSUN?.ToInt() == -1 ? null : this.V0CFEN_VALADTSUN))} ,  {FieldThreatment((this.VIND_DTPAGSUN?.ToInt() == -1 ? null : this.V0CFEN_DTPAGSUN))})";

            return query;
        }
        public string V0CFEN_CODEMP { get; set; }
        public string V0CFEN_NUMBIL { get; set; }
        public string V0CFEN_AGECOBR { get; set; }
        public string V0CFEN_VALADT { get; set; }
        public string V0CFEN_DTCREDITO { get; set; }
        public string V0CFEN_MATRICULA { get; set; }
        public string V0CFEN_AGECONTA { get; set; }
        public string V0CFEN_OPECONTA { get; set; }
        public string V0CFEN_NUMCONTA { get; set; }
        public string V0CFEN_DIGCONTA { get; set; }
        public string V0CFEN_AGECTADEB { get; set; }
        public string V0CFEN_OPRCTADEB { get; set; }
        public string V0CFEN_NUMCTADEB { get; set; }
        public string V0CFEN_DIGCTADEB { get; set; }
        public string V0CFEN_SINDICO { get; set; }
        public string V0CFEN_DTQITBCO { get; set; }
        public string V0CFEN_VLRCAP { get; set; }
        public string V0CFEN_DTMOVTO { get; set; }
        public string V0CFEN_SITUACAO { get; set; }
        public string V0CFEN_NRMATRGER { get; set; }
        public string VIND_NRMATRGER { get; set; }
        public string V0CFEN_VALADTGER { get; set; }
        public string VIND_VALADTGER { get; set; }
        public string V0CFEN_DTPAGGER { get; set; }
        public string VIND_DTPAGGER { get; set; }
        public string V0CFEN_DTCANCEL { get; set; }
        public string VIND_DTCANCEL { get; set; }
        public string V0CFEN_NRMATRSUN { get; set; }
        public string VIND_NRMATRSUN { get; set; }
        public string V0CFEN_VALADTSUN { get; set; }
        public string VIND_VALADTSUN { get; set; }
        public string V0CFEN_DTPAGSUN { get; set; }
        public string VIND_DTPAGSUN { get; set; }

        public static void Execute(R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1 r6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1)
        {
            var ths = r6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6100_00_INSERT_V0COMISFENAE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}