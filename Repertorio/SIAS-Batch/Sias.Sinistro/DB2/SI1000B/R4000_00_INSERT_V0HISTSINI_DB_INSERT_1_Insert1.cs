using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI1000B
{
    public class R4000_00_INSERT_V0HISTSINI_DB_INSERT_1_Insert1 : QueryBasis<R4000_00_INSERT_V0HISTSINI_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0HISTSINI
            (COD_EMPRESA,
            TIPREG,
            NUM_APOL_SINISTRO,
            OCORHIST,
            OPERACAO,
            DTMOVTO,
            HORAOPER,
            NOMFAV,
            VAL_OPERACAO,
            LIMCRR,
            TIPFAV,
            DATNEG,
            FONPAG,
            CODPSVI,
            CODSVI,
            NUMOPG,
            NUMREC,
            MOVPCS,
            CODUSU,
            SITCONTB,
            SITUACAO,
            TIMESTAMP,
            NUM_APOLICE,
            COD_PRODUTO,
            NOM_PROGRAMA)
            VALUES (:V0HSIN-COD-EMP,
            :V0HSIN-TIPREG,
            :V0HSIN-NUM-SINI,
            :V0HSIN-OCORHIST,
            :V0HSIN-OPERACAO,
            :V0HSIN-DTMOVTO,
            :V0HSIN-HORAOPER,
            :V0HSIN-NOMFAV,
            :V0HSIN-VAL-OPER,
            :V0HSIN-LIMCRR,
            :V0HSIN-TIPFAV,
            :V0HSIN-DATNEG,
            :V0HSIN-FONPAG,
            :V0HSIN-CODPSVI,
            :V0HSIN-CODSVI,
            :V0HSIN-NUMOPG,
            :V0HSIN-NUMREC,
            :V0HSIN-MOVPCS,
            :V0HSIN-CODUSU,
            :V0HSIN-SITCONTB,
            :V0HSIN-SITUACAO,
            CURRENT TIMESTAMP,
            :V0HSIN-NUM-APOL,
            :V0HSIN-CODPRODU,
            'SI1000B' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTSINI (COD_EMPRESA, TIPREG, NUM_APOL_SINISTRO, OCORHIST, OPERACAO, DTMOVTO, HORAOPER, NOMFAV, VAL_OPERACAO, LIMCRR, TIPFAV, DATNEG, FONPAG, CODPSVI, CODSVI, NUMOPG, NUMREC, MOVPCS, CODUSU, SITCONTB, SITUACAO, TIMESTAMP, NUM_APOLICE, COD_PRODUTO, NOM_PROGRAMA) VALUES ({FieldThreatment(this.V0HSIN_COD_EMP)}, {FieldThreatment(this.V0HSIN_TIPREG)}, {FieldThreatment(this.V0HSIN_NUM_SINI)}, {FieldThreatment(this.V0HSIN_OCORHIST)}, {FieldThreatment(this.V0HSIN_OPERACAO)}, {FieldThreatment(this.V0HSIN_DTMOVTO)}, {FieldThreatment(this.V0HSIN_HORAOPER)}, {FieldThreatment(this.V0HSIN_NOMFAV)}, {FieldThreatment(this.V0HSIN_VAL_OPER)}, {FieldThreatment(this.V0HSIN_LIMCRR)}, {FieldThreatment(this.V0HSIN_TIPFAV)}, {FieldThreatment(this.V0HSIN_DATNEG)}, {FieldThreatment(this.V0HSIN_FONPAG)}, {FieldThreatment(this.V0HSIN_CODPSVI)}, {FieldThreatment(this.V0HSIN_CODSVI)}, {FieldThreatment(this.V0HSIN_NUMOPG)}, {FieldThreatment(this.V0HSIN_NUMREC)}, {FieldThreatment(this.V0HSIN_MOVPCS)}, {FieldThreatment(this.V0HSIN_CODUSU)}, {FieldThreatment(this.V0HSIN_SITCONTB)}, {FieldThreatment(this.V0HSIN_SITUACAO)}, CURRENT TIMESTAMP, {FieldThreatment(this.V0HSIN_NUM_APOL)}, {FieldThreatment(this.V0HSIN_CODPRODU)}, 'SI1000B' )";

            return query;
        }
        public string V0HSIN_COD_EMP { get; set; }
        public string V0HSIN_TIPREG { get; set; }
        public string V0HSIN_NUM_SINI { get; set; }
        public string V0HSIN_OCORHIST { get; set; }
        public string V0HSIN_OPERACAO { get; set; }
        public string V0HSIN_DTMOVTO { get; set; }
        public string V0HSIN_HORAOPER { get; set; }
        public string V0HSIN_NOMFAV { get; set; }
        public string V0HSIN_VAL_OPER { get; set; }
        public string V0HSIN_LIMCRR { get; set; }
        public string V0HSIN_TIPFAV { get; set; }
        public string V0HSIN_DATNEG { get; set; }
        public string V0HSIN_FONPAG { get; set; }
        public string V0HSIN_CODPSVI { get; set; }
        public string V0HSIN_CODSVI { get; set; }
        public string V0HSIN_NUMOPG { get; set; }
        public string V0HSIN_NUMREC { get; set; }
        public string V0HSIN_MOVPCS { get; set; }
        public string V0HSIN_CODUSU { get; set; }
        public string V0HSIN_SITCONTB { get; set; }
        public string V0HSIN_SITUACAO { get; set; }
        public string V0HSIN_NUM_APOL { get; set; }
        public string V0HSIN_CODPRODU { get; set; }

        public static void Execute(R4000_00_INSERT_V0HISTSINI_DB_INSERT_1_Insert1 r4000_00_INSERT_V0HISTSINI_DB_INSERT_1_Insert1)
        {
            var ths = r4000_00_INSERT_V0HISTSINI_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4000_00_INSERT_V0HISTSINI_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}