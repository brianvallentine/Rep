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
    public class R7650_00_INSERT_V0BILHETE_DB_INSERT_1_Insert1 : QueryBasis<R7650_00_INSERT_V0BILHETE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0BILHETE
            VALUES (:V0BILH-NUMBIL ,
            :V0BILH-NUMAPOL ,
            :V0BILH-FONTE ,
            :V0BILH-AGECOBR ,
            :V0BILH-MATRICULA ,
            :V0BILH-AGECONTA ,
            :V0BILH-OPECONTA ,
            :V0BILH-NUMCONTA ,
            :V0BILH-DIGCONTA ,
            :V0BILH-CODCLIEN ,
            :V0BILH-PROFISSAO ,
            :V0BILH-SEXO ,
            :V0BILH-ESTCIV ,
            :V0BILH-OCOREND ,
            :V0BILH-AGECONDEB ,
            :V0BILH-OPECONDEB ,
            :V0BILH-NUMCONDEB ,
            :V0BILH-DIGCONDEB ,
            :V0BILH-OPCOBER ,
            :V0BILH-DTQITBCO ,
            :V0BILH-VLRCAP ,
            :V0BILH-RAMO ,
            :V0BILH-DTVENDA ,
            :V0BILH-DTMOVTO ,
            :V0BILH-NUMAPOLANT ,
            :V0BILH-SITUACAO ,
            :V0BILH-TIPCANCEL ,
            :V0BILH-TIPSINIST ,
            :V0BILH-CODUSU ,
            CURRENT TIMESTAMP ,
            :V0BILH-DTCANCEL:VIND-DTCANCEL,
            :V0BILH-FX-RENDA-IND ,
            :V0BILH-FX-RENDA-FAM ,
            :V0BILH-COD-PRODUTO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0BILHETE VALUES ({FieldThreatment(this.V0BILH_NUMBIL)} , {FieldThreatment(this.V0BILH_NUMAPOL)} , {FieldThreatment(this.V0BILH_FONTE)} , {FieldThreatment(this.V0BILH_AGECOBR)} , {FieldThreatment(this.V0BILH_MATRICULA)} , {FieldThreatment(this.V0BILH_AGECONTA)} , {FieldThreatment(this.V0BILH_OPECONTA)} , {FieldThreatment(this.V0BILH_NUMCONTA)} , {FieldThreatment(this.V0BILH_DIGCONTA)} , {FieldThreatment(this.V0BILH_CODCLIEN)} , {FieldThreatment(this.V0BILH_PROFISSAO)} , {FieldThreatment(this.V0BILH_SEXO)} , {FieldThreatment(this.V0BILH_ESTCIV)} , {FieldThreatment(this.V0BILH_OCOREND)} , {FieldThreatment(this.V0BILH_AGECONDEB)} , {FieldThreatment(this.V0BILH_OPECONDEB)} , {FieldThreatment(this.V0BILH_NUMCONDEB)} , {FieldThreatment(this.V0BILH_DIGCONDEB)} , {FieldThreatment(this.V0BILH_OPCOBER)} , {FieldThreatment(this.V0BILH_DTQITBCO)} , {FieldThreatment(this.V0BILH_VLRCAP)} , {FieldThreatment(this.V0BILH_RAMO)} , {FieldThreatment(this.V0BILH_DTVENDA)} , {FieldThreatment(this.V0BILH_DTMOVTO)} , {FieldThreatment(this.V0BILH_NUMAPOLANT)} , {FieldThreatment(this.V0BILH_SITUACAO)} , {FieldThreatment(this.V0BILH_TIPCANCEL)} , {FieldThreatment(this.V0BILH_TIPSINIST)} , {FieldThreatment(this.V0BILH_CODUSU)} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_DTCANCEL?.ToInt() == -1 ? null : this.V0BILH_DTCANCEL))}, {FieldThreatment(this.V0BILH_FX_RENDA_IND)} , {FieldThreatment(this.V0BILH_FX_RENDA_FAM)} , {FieldThreatment(this.V0BILH_COD_PRODUTO)})";

            return query;
        }
        public string V0BILH_NUMBIL { get; set; }
        public string V0BILH_NUMAPOL { get; set; }
        public string V0BILH_FONTE { get; set; }
        public string V0BILH_AGECOBR { get; set; }
        public string V0BILH_MATRICULA { get; set; }
        public string V0BILH_AGECONTA { get; set; }
        public string V0BILH_OPECONTA { get; set; }
        public string V0BILH_NUMCONTA { get; set; }
        public string V0BILH_DIGCONTA { get; set; }
        public string V0BILH_CODCLIEN { get; set; }
        public string V0BILH_PROFISSAO { get; set; }
        public string V0BILH_SEXO { get; set; }
        public string V0BILH_ESTCIV { get; set; }
        public string V0BILH_OCOREND { get; set; }
        public string V0BILH_AGECONDEB { get; set; }
        public string V0BILH_OPECONDEB { get; set; }
        public string V0BILH_NUMCONDEB { get; set; }
        public string V0BILH_DIGCONDEB { get; set; }
        public string V0BILH_OPCOBER { get; set; }
        public string V0BILH_DTQITBCO { get; set; }
        public string V0BILH_VLRCAP { get; set; }
        public string V0BILH_RAMO { get; set; }
        public string V0BILH_DTVENDA { get; set; }
        public string V0BILH_DTMOVTO { get; set; }
        public string V0BILH_NUMAPOLANT { get; set; }
        public string V0BILH_SITUACAO { get; set; }
        public string V0BILH_TIPCANCEL { get; set; }
        public string V0BILH_TIPSINIST { get; set; }
        public string V0BILH_CODUSU { get; set; }
        public string V0BILH_DTCANCEL { get; set; }
        public string VIND_DTCANCEL { get; set; }
        public string V0BILH_FX_RENDA_IND { get; set; }
        public string V0BILH_FX_RENDA_FAM { get; set; }
        public string V0BILH_COD_PRODUTO { get; set; }

        public static void Execute(R7650_00_INSERT_V0BILHETE_DB_INSERT_1_Insert1 r7650_00_INSERT_V0BILHETE_DB_INSERT_1_Insert1)
        {
            var ths = r7650_00_INSERT_V0BILHETE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7650_00_INSERT_V0BILHETE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}